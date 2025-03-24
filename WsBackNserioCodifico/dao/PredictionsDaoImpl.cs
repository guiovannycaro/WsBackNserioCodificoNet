using BacktecnoFactApi.Infraestructura.Util;
using System.Data.SqlClient;
using System.Text.Json;
using WsBackNserioCodifico.interfaces;
using WsBackNserioCodifico.Modelos;
using System.Globalization;
using System.Runtime.InteropServices.JavaScript;
using static System.Runtime.InteropServices.JavaScript.JSType;



namespace WsBackNserioCodifico.dao
{
    public class PredictionsDaoImpl : IpredictionsInter
    {

        private ExecuteQueryBD _conectionString;
        SqlDataReader dr;

        public PredictionsDaoImpl(ExecuteQueryBD conectionString)
        {
            _conectionString = conectionString;
        }

        public List<Predictions> devolverTodos()
        {
            List<Predictions> list = new List<Predictions>();
            DateTime proximaFecha = new DateTime();

            string sql = "SELECT c.custid, c.companyname, c.contactname, o.orderdate " +
                         "FROM sales.Orders o " +
                         "JOIN sales.Customers c ON o.custid = c.custid";

            var parametros = new Dictionary<string, object>();

            using (SqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                    int custId = dr.GetInt32(dr.GetOrdinal("custid"));
                    DateTime fechaUltima = dr.GetDateTime(dr.GetOrdinal("orderdate"));

                  
                    List<OrderDate> listCust = BuscarDetailsOrderById(custId);

                  
                    proximaFecha = CalcularProximaOrden(listCust, fechaUltima);

                    Predictions categorias = new Predictions(
                        custId,
                        dr.IsDBNull(dr.GetOrdinal("companyname")) ? string.Empty : dr.GetString(dr.GetOrdinal("companyname")),
                        dr.IsDBNull(dr.GetOrdinal("contactname")) ? string.Empty : dr.GetString(dr.GetOrdinal("contactname")),
                        dr.IsDBNull(dr.GetOrdinal("orderdate")) ? DateTime.MinValue : fechaUltima,
                        proximaFecha
                    );

                    list.Add(categorias);
                }
            }

            return list;
        }


        public bool agregarRegistro(NOrderDetail datos)
        {

            bool respuesta;

          
            string formatoFecha = "yyyy-MM-ddTHH:mm:ss.fffZ";

            string orderdateString = ""+datos.orderdate;
            string requireddateString = "" + datos.requireddate;
            string shippeddateString = "" + datos.shippeddate;

            DateTime orderdates = DateTime.Parse(orderdateString, null, DateTimeStyles.AssumeUniversal);
            Console.WriteLine("Fecha en UTC: " + orderdates.ToString("yyyy-MM-dd HH:mm:ss.fff"));

            DateTime requireddates = DateTime.Parse(requireddateString, null, DateTimeStyles.AssumeUniversal);
            Console.WriteLine("Fecha en UTC: " + requireddates.ToString("yyyy-MM-dd HH:mm:ss.fff"));

            DateTime shippeddate = DateTime.Parse(shippeddateString, null, DateTimeStyles.AssumeUniversal);
            Console.WriteLine("Fecha en UTC: " + requireddates.ToString("yyyy-MM-dd HH:mm:ss.fff"));


            Console.WriteLine(datos.empid); Console.WriteLine(datos.shipperid);

            string sql = "INSERT INTO Sales.Orders" +
               " (custid, empid,orderdate,requireddate,shippeddate," +
               " shipperid,freight,shipname,shipaddress,shipcity," +
               " shipregion,shippostalcode,shipcountry) " +
               "VALUES" +
               " (@custid, @empid,@orderdate,@requireddate,@shippeddate," +
               " @shipperid,@freight,@shipname,@shipaddress,@shipcity," +
               " @shipregion,@shippostalcode,@shipcountry) ";

            var parameters = new Dictionary<string, object>
    {
        { "@custid", datos.custid },
        { "@empid", datos.empid },
        { "@orderdate", orderdates },
        { "@requireddate", requireddates },
        { "@shippeddate", shippeddate },
        { "@shipperid", datos.shipperid },
        { "@freight", datos.freight },
        { "@shipname", datos.shipname },
        { "@shipaddress", datos.shipaddress },
        { "@shipcity", datos.shipcity },
         { "@shipregion", datos.shipregion },
        { "@shippostalcode", datos.shippostalcode },
        { "@shipcountry", datos.shipcountry }
            };
            int orderid = 0;

            

             _conectionString.ExecuteScalarBd(sql, parameters);

            orderid = CustomerEmplRegistroPorId( datos.empid, datos.custid);

            Console.WriteLine(orderid);

            if (orderid > 0)
            {
                string sqld = "INSERT INTO Sales.OrderDetails " +
                           "(orderid, productid, unitprice, qty, discount) " +
                           "VALUES (@Orderid, @productid, @unitprice, @qty, @discount);";

                var parametersd = new Dictionary<string, object>
    {
        { "@Orderid", orderid },
        { "@productid", datos.productid },
        { "@unitprice", datos.unitprice },
        { "@qty", datos.qty },
        { "@discount", datos.discount }
    };

                respuesta = _conectionString.ExecuteUpdateBd(sqld, parametersd);

                if (respuesta)
                {
                    respuesta = true;
                }
                else
                {
                    respuesta = false;
                }
              

            }
            else {
                respuesta = false;
            }

            return respuesta;
        }

        public bool actualizarRegistros(Predictions datos)
        {
            throw new NotImplementedException();
        }



        public int CustomerEmplRegistroPorId(int dato1,int dato2)
        {
            string sql = " select TOP 1 orderid from Sales.Orders"
                 + " WHERE custid = @CustId and empid = @EmpId" +
                 " ORDER BY orderid DESC";

            int dato = 0;

            var parametros = new Dictionary<string, object>
            {
              { "@EmpId", dato1 },
              { "@CustId", dato2 }
            };

            using (SqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {

                    dato = dr.GetInt32(dr.GetOrdinal("orderid"));
                }

                Console.WriteLine("id tabla orden " + dato);
            }

            return dato;
        }

        public Predictions buscarRegistroNombre(string datos)
        {
            throw new NotImplementedException();
        }

        public List<Predictions> buscarRegistroPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Predictions> devolverFecOrdenPosOrden(int cust, JSType.Date fechaOrden, JSType.Date fechaPosOrden)
        {
            throw new NotImplementedException();
        }

     

        public bool eliminarRegistro(int id)
        {
            throw new NotImplementedException();
        }


        public List<OrderDate> BuscarDetailsOrderById(int id)
        {
            List<OrderDate> list = new List<OrderDate>();
            string sql = "   select o.orderdate from sales.OrderDetails s  " 
+ "  join sales.Orders o on s.orderid = o.orderid " 
+ "  join sales.Customers c on o.custid = c.custid " 
+ "  join production.Products p on s.productid = p.productid  where c.custid = @CusId";
            Console.WriteLine(sql);

            var parametros = new Dictionary<string, object>
            {
              { "@CusId", id }
            };

            using (SqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                    OrderDate categorias = new OrderDate(
         dr.IsDBNull(dr.GetOrdinal("orderdate")) ? DateTime.MinValue : dr.GetDateTime(dr.GetOrdinal("orderdate"))
        );

                    list.Add(categorias);
                }
            }

            return list;
        }

        public DateTime CalcularProximaOrden(List<OrderDate> listCust, DateTime fechaUltima)
        {
            if (listCust == null || listCust.Count == 0)
                return fechaUltima;

            int totalDias = 0;
            int intervalos = listCust.Count;

            foreach (OrderDate orden in listCust)
            {
                DateTime fecha = orden.orderdate;  
                int dias = (fechaUltima - fecha).Days;
                totalDias += dias;
            }

            int promedioDias = intervalos > 0 ? totalDias / intervalos : 0;

            DateTime proximaOrden = fechaUltima.AddDays(promedioDias);
            return proximaOrden;
        }
    }
}
