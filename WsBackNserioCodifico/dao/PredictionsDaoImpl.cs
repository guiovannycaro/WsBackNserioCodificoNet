using BacktecnoFactApi.Infraestructura.Util;
using System.Data.SqlClient;
using System.Text.Json;
using WsBackNserioCodifico.interfaces;
using WsBackNserioCodifico.Modelos;

using System.Runtime.InteropServices.JavaScript;


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

        public bool actualizarRegistros(Predictions datos)
        {
            throw new NotImplementedException();
        }

        public bool agregarRegistro(Predictions datos)
        {
            throw new NotImplementedException();
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
