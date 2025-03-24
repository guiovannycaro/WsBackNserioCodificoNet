using BacktecnoFactApi.Infraestructura.Util;
using System.Data.SqlClient;
using System.Globalization;
using System.Text.Json;
using WsBackNserioCodifico.interfaces;
using WsBackNserioCodifico.Modelos;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WsBackNserioCodifico.dao
{
    public class OrderDetailsDaoImpl : IOrderDetailsInter
    {

        private ExecuteQueryBD _conectionString;
        SqlDataReader dr;

        public OrderDetailsDaoImpl(ExecuteQueryBD conectionString)
        {
            _conectionString = conectionString;
        }


        public List<OrderDetails> devolverTodos()
        {

            List<OrderDetails> list = new List<OrderDetails>();

            string sql = " select" +
                "orderid ," +
                "productid, " +
                "CAST(unitprice AS NUMERIC(19, 4)) AS unitprice, " +
                "qty," +
               "CAST(discount AS NUMERIC(19, 4)) AS discount " +
                "  from Sales.OrderDetails";



            var parametros = new Dictionary<string, object>
            {

            };

            using (SqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {

                    // Imprimir el tipo y el valor del unitprice y discount
                    Console.WriteLine($"Tipo de unitprice: {dr.GetValue(dr.GetOrdinal("unitprice")).GetType().FullName}");
                    Console.WriteLine($"Valor de unitprice: {dr.GetValue(dr.GetOrdinal("unitprice")).ToString()}");

                    decimal unitPriceValue = dr.GetSqlDecimal(dr.GetOrdinal("unitprice")).Value;
                    decimal discountValue = dr.GetSqlDecimal(dr.GetOrdinal("discount")).Value;

                    OrderDetails categorias = new OrderDetails(
                        dr.IsDBNull(dr.GetOrdinal("orderid")) ? 0 : dr.GetInt32(dr.GetOrdinal("orderid")),
                        dr.IsDBNull(dr.GetOrdinal("productid")) ? 0 : dr.GetInt32(dr.GetOrdinal("productid")),
                        unitPriceValue,
                        dr.IsDBNull(dr.GetOrdinal("qty")) ? 0 : dr.GetInt32(dr.GetOrdinal("qty")),
                        discountValue
                    );

                    list.Add(categorias);
                }
            }

            return list;
        }


        public bool agregarRegistro(OrderDetails datos)
        {
            bool respuesta;
            string sql = "INSERT INTO Sales.OrderDetails " +
                "(productid, unitprice,qty,discount) " +
                "VALUES (@productid, @unitprice,@qty,@discount) ";
            var parameters = new Dictionary<string, object>
    {
        { "@productid", datos.productid },
        { "@unitprice", datos.unitprice },
        { "@qty", datos.qty },
        { "@discount", datos.discount }
    };

            bool rpt = _conectionString.ExecuteUpdateBd(sql, parameters);


            if (rpt)
            {

                respuesta = true;
            }
            else
            {
                respuesta = false;
            }



            return respuesta;
        }


        public bool actualizarRegistros(OrderDetails datos)
        {
            bool respuesta;
            string sql = " UPDATE Sales.OrderDetails " +
                " SET " +
                " productid = @productid, " +
                " unitprice = @unitprice ," +
                " qty = @qty, " +
                " discount = @discount " +
                " WHERE orderid = @orderid";

            var parameters = new Dictionary<string, object>
    {
        { "@orderid", datos.orderid },
       { "@productid", datos.productid },
        { "@unitprice", datos.unitprice },
        { "@qty", datos.qty },
        { "@discount", datos.discount }
    };

            bool rpt = _conectionString.ExecuteUpdateBd(sql, parameters);


            if (rpt)
            {

                respuesta = true;
            }
            else
            {
                respuesta = false;
            }



            return respuesta;
        }


        public bool eliminarRegistro(int id)
        {
            bool respuesta;
            string sql = "DELETE FROM Sales.OrderDetails " +
               " WHERE orderid = @shipperid";

            var parameters = new Dictionary<string, object>
    {
        { "@shipperid", id },

    };

            bool rpt = _conectionString.ExecuteUpdateBd(sql, parameters);


            if (rpt)
            {

                respuesta = true;
            }
            else
            {
                respuesta = false;
            }



            return respuesta;
        }

        public OrderDetails buscarRegistroNombre(int datos)
        {
            string sql = " select * from Sales.OrderDetails"
                 + " WHERE productid = @CategoryN";

            OrderDetails categorias = null;

            var parametros = new Dictionary<string, object>
            {
              { "@CategoryN", datos }
            };

            using (SqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                     categorias = new OrderDetails(
    dr.IsDBNull(dr.GetOrdinal("orderid")) ? 0 : dr.GetInt32(dr.GetOrdinal("orderid")),
    dr.IsDBNull(dr.GetOrdinal("productid")) ? 0 : dr.GetInt32(dr.GetOrdinal("productid")),
    dr.IsDBNull(dr.GetOrdinal("unitprice")) ? 0m : dr.GetDecimal(dr.GetOrdinal("unitprice")),
    dr.IsDBNull(dr.GetOrdinal("qty")) ? 0 : dr.GetInt32(dr.GetOrdinal("qty")),
    dr.IsDBNull(dr.GetOrdinal("discount")) ? 0m : dr.GetDecimal(dr.GetOrdinal("discount"))
);

                }
            }

            return categorias;

        }

        public List<OrderDetails> buscarRegistroPorId(int id)
        {
            List<OrderDetails> list = new List<OrderDetails>();

            string sql = " select * from Sales.OrderDetails"
                 + " WHERE orderid = @CategoryId";

            OrderDetails categorias = null;

            var parametros = new Dictionary<string, object>
            {
              { "@CategoryId", id }
            };

            using (SqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                     categorias = new OrderDetails(
     dr.IsDBNull(dr.GetOrdinal("orderid")) ? 0 : dr.GetInt32(dr.GetOrdinal("orderid")),
     dr.IsDBNull(dr.GetOrdinal("productid")) ? 0 : dr.GetInt32(dr.GetOrdinal("productid")),
     dr.IsDBNull(dr.GetOrdinal("unitprice")) ? 0m : dr.GetDecimal(dr.GetOrdinal("unitprice")),
     dr.IsDBNull(dr.GetOrdinal("qty")) ? 0 : dr.GetInt32(dr.GetOrdinal("qty")),
     dr.IsDBNull(dr.GetOrdinal("discount")) ? 0m : dr.GetDecimal(dr.GetOrdinal("discount"))
 );

                    list.Add(categorias);
                }
            }

            return list;

        }

        public List<DetailsOrders> BuscarDetailsOrderById(int id)
        {
            List<DetailsOrders> list = new List<DetailsOrders>();
            string sql = " select o.orderid,c.companyname,c.contactname,p.productname,s.unitprice,s.qty,s.discount from sales.OrderDetails s "
+ " join sales.Orders o on s.orderid = o.orderid "
+ " join sales.Customers c on o.custid = c.custid "
+ " join production.Products p on s.productid = p.productid "
+ " where s.orderid = @OrderId ";
            Console.WriteLine(sql);

            var parametros = new Dictionary<string, object>
            {
              { "@OrderId", id }
            };

            using (SqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                    DetailsOrders categorias = new DetailsOrders(
          dr.IsDBNull(dr.GetOrdinal("orderid")) ? 0 : dr.GetInt32(dr.GetOrdinal("orderid")),
        dr.IsDBNull(dr.GetOrdinal("companyname")) ? "" : dr.GetString(dr.GetOrdinal("companyname")),
        dr.IsDBNull(dr.GetOrdinal("contactname")) ? "" : dr.GetString(dr.GetOrdinal("contactname")),
        dr.IsDBNull(dr.GetOrdinal("productname")) ? "" : dr.GetString(dr.GetOrdinal("productname")),
        dr.IsDBNull(dr.GetOrdinal("unitprice")) ? 0m : dr.GetDecimal(dr.GetOrdinal("unitprice")),
        dr.IsDBNull(dr.GetOrdinal("qty")) ? 0 : Convert.ToInt32(dr.GetValue(dr.GetOrdinal("qty"))),  // Usando Convert.ToInt32
        dr.IsDBNull(dr.GetOrdinal("discount")) ? 0m : dr.GetDecimal(dr.GetOrdinal("discount"))
        );

                    list.Add(categorias);
                }
            }

            return list;
        }
    }
}
