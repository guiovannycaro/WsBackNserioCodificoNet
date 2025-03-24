using BacktecnoFactApi.Infraestructura.Util;
using System.Data.SqlClient;
using System.Text.Json;
using WsBackNserioCodifico.interfaces;
using WsBackNserioCodifico.Modelos;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WsBackNserioCodifico.dao
{
    public class OrdersDaoImpl : IOrdersInter
    {

        private ExecuteQueryBD _conectionString;
        SqlDataReader dr;

        public OrdersDaoImpl(ExecuteQueryBD conectionString)
        {
            _conectionString = conectionString;
        }


        public List<Orders> devolverTodos()
        {

            List<Orders> list = new List<Orders>();

            string sql = " select * from Sales.Orders ";



            var parametros = new Dictionary<string, object>
            {

            };

            using (SqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                    Orders categorias = new Orders(
    dr.IsDBNull(dr.GetOrdinal("orderid")) ? 0 : dr.GetInt32(dr.GetOrdinal("orderid")),
    dr.IsDBNull(dr.GetOrdinal("custid")) ? 0 : dr.GetInt32(dr.GetOrdinal("custid")),
    dr.IsDBNull(dr.GetOrdinal("empid")) ? 0 : dr.GetInt32(dr.GetOrdinal("empid")),
    dr.IsDBNull(dr.GetOrdinal("orderdate")) ? DateTime.MinValue : dr.GetDateTime(dr.GetOrdinal("orderdate")),
    dr.IsDBNull(dr.GetOrdinal("requireddate")) ? DateTime.MinValue : dr.GetDateTime(dr.GetOrdinal("requireddate")),
    dr.IsDBNull(dr.GetOrdinal("shippeddate")) ? DateTime.MinValue : dr.GetDateTime(dr.GetOrdinal("shippeddate")),
    dr.IsDBNull(dr.GetOrdinal("shipperid")) ? 0 : dr.GetInt32(dr.GetOrdinal("shipperid")),
    dr.IsDBNull(dr.GetOrdinal("freight")) ? 0m : dr.GetDecimal(dr.GetOrdinal("freight")),
    dr.IsDBNull(dr.GetOrdinal("shipname")) ? string.Empty : dr.GetString(dr.GetOrdinal("shipname")),
    dr.IsDBNull(dr.GetOrdinal("shipaddress")) ? string.Empty : dr.GetString(dr.GetOrdinal("shipaddress")),
    dr.IsDBNull(dr.GetOrdinal("shipcity")) ? string.Empty : dr.GetString(dr.GetOrdinal("shipcity")),
    dr.IsDBNull(dr.GetOrdinal("shipregion")) ? string.Empty : dr.GetString(dr.GetOrdinal("shipregion")),
    dr.IsDBNull(dr.GetOrdinal("shippostalcode")) ? string.Empty : dr.GetString(dr.GetOrdinal("shippostalcode")),
    dr.IsDBNull(dr.GetOrdinal("shipcountry")) ? string.Empty : dr.GetString(dr.GetOrdinal("shipcountry"))
);
                    list.Add(categorias);
                }
            }

            return list;
        }


        public bool agregarRegistro(Orders datos)
        {
            bool respuesta;
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
        { "@orderdate", datos.orderdate },
        { "@requireddate", datos.requireddate }, 
        { "@shippeddate", datos.shippeddate },
        { "@shipperid", datos.shipperid },
        { "@freight", datos.freight },
        { "@shipname", datos.shipname },
        { "@shipaddress", datos.shipaddress },
        { "@shipcity", datos.shipcity },
         { "@shipregion", datos.shipregion },
        { "@shippostalcode", datos.shippostalcode },
        { "@shipcountry", datos.shipcountry }
      

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


        public bool actualizarRegistros(Orders datos)
        {
            bool respuesta;
            string sql = " UPDATE Sales.Orders " +
                " SET custid = @custid, " +
                " empid = @empid, " +
                " orderdate = @orderdate, " +
                " requireddate = @requireddate, " +
                " shippeddate = @shippeddate, " +
                " shipperid = @shipperid, " +
                " freight = @freight, " +
                " shipname = @shipname, " +
                " shipaddress = @shipaddress, " +
                " shipcity = @shipcity, " +
                " shipregion = @shipregion, " +
                " shippostalcode = @shippostalcode, " +
                " shipcountry = @shipcountry " +
                " WHERE orderid = @orderid";

            var parameters = new Dictionary<string, object>
    {
        { "@orderid", datos.orderid },
        { "@custid", datos.custid },
        { "@empid", datos.empid },
        { "@orderdate", datos.orderdate },
        { "@requireddate", datos.requireddate },
        { "@shippeddate", datos.shippeddate },
        { "@shipperid", datos.shipperid },
        { "@freight", datos.freight },
        { "@shipname", datos.shipname },
        { "@shipaddress", datos.shipaddress },
        { "@shipcity", datos.shipcity },
         { "@shipregion", datos.shipregion },
        { "@shippostalcode", datos.shippostalcode },
        { "@shipcountry", datos.shipcountry }
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
            string sql = " DELETE FROM Sales.Orders " +
               " WHERE orderid = @CategoryId ";

            var parameters = new Dictionary<string, object>
    {
        { "@CategoryId", id },

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

        public Orders buscarRegistroNombre(string datos)
        {
            string sql = " select * from Sales.Orders"
                 + " WHERE shipname = @CategoryN";

            Orders categorias = null;

            var parametros = new Dictionary<string, object>
            {
              { "@CategoryN", datos }
            };

            using (SqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                     categorias = new Orders(
     dr.IsDBNull(dr.GetOrdinal("orderid")) ? 0 : dr.GetInt32(dr.GetOrdinal("orderid")),
     dr.IsDBNull(dr.GetOrdinal("custid")) ? 0 : dr.GetInt32(dr.GetOrdinal("custid")),
     dr.IsDBNull(dr.GetOrdinal("empid")) ? 0 : dr.GetInt32(dr.GetOrdinal("empid")),
     dr.IsDBNull(dr.GetOrdinal("orderdate")) ? DateTime.MinValue : dr.GetDateTime(dr.GetOrdinal("orderdate")),
     dr.IsDBNull(dr.GetOrdinal("requireddate")) ? DateTime.MinValue : dr.GetDateTime(dr.GetOrdinal("requireddate")),
     dr.IsDBNull(dr.GetOrdinal("shippeddate")) ? DateTime.MinValue : dr.GetDateTime(dr.GetOrdinal("shippeddate")),
     dr.IsDBNull(dr.GetOrdinal("shipperid")) ? 0 : dr.GetInt32(dr.GetOrdinal("shipperid")),
     dr.IsDBNull(dr.GetOrdinal("freight")) ? 0m : dr.GetDecimal(dr.GetOrdinal("freight")),
     dr.IsDBNull(dr.GetOrdinal("shipname")) ? string.Empty : dr.GetString(dr.GetOrdinal("shipname")),
     dr.IsDBNull(dr.GetOrdinal("shipaddress")) ? string.Empty : dr.GetString(dr.GetOrdinal("shipaddress")),
     dr.IsDBNull(dr.GetOrdinal("shipcity")) ? string.Empty : dr.GetString(dr.GetOrdinal("shipcity")),
     dr.IsDBNull(dr.GetOrdinal("shipregion")) ? string.Empty : dr.GetString(dr.GetOrdinal("shipregion")),
     dr.IsDBNull(dr.GetOrdinal("shippostalcode")) ? string.Empty : dr.GetString(dr.GetOrdinal("shippostalcode")),
     dr.IsDBNull(dr.GetOrdinal("shipcountry")) ? string.Empty : dr.GetString(dr.GetOrdinal("shipcountry"))
 );

                }
            }

            return categorias;

        }

        public List<Orders> buscarRegistroPorId(int id)
        {

            List<Orders> list = new List<Orders>();
            string sql = " select * from Sales.Orders "
                 + " WHERE orderid = @CategoryId ";

            Orders categorias = null;

            var parametros = new Dictionary<string, object>
            {
              { "@CategoryId", id }
            };

            using (SqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                     categorias = new Orders(
   dr.IsDBNull(dr.GetOrdinal("orderid")) ? 0 : dr.GetInt32(dr.GetOrdinal("orderid")),
   dr.IsDBNull(dr.GetOrdinal("custid")) ? 0 : dr.GetInt32(dr.GetOrdinal("custid")),
   dr.IsDBNull(dr.GetOrdinal("empid")) ? 0 : dr.GetInt32(dr.GetOrdinal("empid")),
   dr.IsDBNull(dr.GetOrdinal("orderdate")) ? DateTime.MinValue : dr.GetDateTime(dr.GetOrdinal("orderdate")),
   dr.IsDBNull(dr.GetOrdinal("requireddate")) ? DateTime.MinValue : dr.GetDateTime(dr.GetOrdinal("requireddate")),
   dr.IsDBNull(dr.GetOrdinal("shippeddate")) ? DateTime.MinValue : dr.GetDateTime(dr.GetOrdinal("shippeddate")),
   dr.IsDBNull(dr.GetOrdinal("shipperid")) ? 0 : dr.GetInt32(dr.GetOrdinal("shipperid")),
   dr.IsDBNull(dr.GetOrdinal("freight")) ? 0m : dr.GetDecimal(dr.GetOrdinal("freight")),
   dr.IsDBNull(dr.GetOrdinal("shipname")) ? string.Empty : dr.GetString(dr.GetOrdinal("shipname")),
   dr.IsDBNull(dr.GetOrdinal("shipaddress")) ? string.Empty : dr.GetString(dr.GetOrdinal("shipaddress")),
   dr.IsDBNull(dr.GetOrdinal("shipcity")) ? string.Empty : dr.GetString(dr.GetOrdinal("shipcity")),
   dr.IsDBNull(dr.GetOrdinal("shipregion")) ? string.Empty : dr.GetString(dr.GetOrdinal("shipregion")),
   dr.IsDBNull(dr.GetOrdinal("shippostalcode")) ? string.Empty : dr.GetString(dr.GetOrdinal("shippostalcode")),
   dr.IsDBNull(dr.GetOrdinal("shipcountry")) ? string.Empty : dr.GetString(dr.GetOrdinal("shipcountry"))
);

                    list.Add(categorias);
                }
            }

            return list;

        }

        public List<Orders> buscarRegistroPorCustomerId(int id)
        {

            List<Orders> list = new List<Orders>();
            string sql = " select * from Sales.Orders "
                 + " WHERE custid = @CustId ";

            Orders categorias = null;

            var parametros = new Dictionary<string, object>
            {
              { "@CustId", id }
            };

            using (SqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                    categorias = new Orders(
  dr.IsDBNull(dr.GetOrdinal("orderid")) ? 0 : dr.GetInt32(dr.GetOrdinal("orderid")),
  dr.IsDBNull(dr.GetOrdinal("custid")) ? 0 : dr.GetInt32(dr.GetOrdinal("custid")),
  dr.IsDBNull(dr.GetOrdinal("empid")) ? 0 : dr.GetInt32(dr.GetOrdinal("empid")),
  dr.IsDBNull(dr.GetOrdinal("orderdate")) ? DateTime.MinValue : dr.GetDateTime(dr.GetOrdinal("orderdate")),
  dr.IsDBNull(dr.GetOrdinal("requireddate")) ? DateTime.MinValue : dr.GetDateTime(dr.GetOrdinal("requireddate")),
  dr.IsDBNull(dr.GetOrdinal("shippeddate")) ? DateTime.MinValue : dr.GetDateTime(dr.GetOrdinal("shippeddate")),
  dr.IsDBNull(dr.GetOrdinal("shipperid")) ? 0 : dr.GetInt32(dr.GetOrdinal("shipperid")),
  dr.IsDBNull(dr.GetOrdinal("freight")) ? 0m : dr.GetDecimal(dr.GetOrdinal("freight")),
  dr.IsDBNull(dr.GetOrdinal("shipname")) ? string.Empty : dr.GetString(dr.GetOrdinal("shipname")),
  dr.IsDBNull(dr.GetOrdinal("shipaddress")) ? string.Empty : dr.GetString(dr.GetOrdinal("shipaddress")),
  dr.IsDBNull(dr.GetOrdinal("shipcity")) ? string.Empty : dr.GetString(dr.GetOrdinal("shipcity")),
  dr.IsDBNull(dr.GetOrdinal("shipregion")) ? string.Empty : dr.GetString(dr.GetOrdinal("shipregion")),
  dr.IsDBNull(dr.GetOrdinal("shippostalcode")) ? string.Empty : dr.GetString(dr.GetOrdinal("shippostalcode")),
  dr.IsDBNull(dr.GetOrdinal("shipcountry")) ? string.Empty : dr.GetString(dr.GetOrdinal("shipcountry"))
);

                    list.Add(categorias);
                }
            }

            return list;

        }
    }
}
