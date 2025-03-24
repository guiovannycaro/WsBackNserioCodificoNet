using BacktecnoFactApi.Infraestructura.Util;
using System.Data.SqlClient;
using System.Text.Json;
using WsBackNserioCodifico.interfaces;
using WsBackNserioCodifico.Modelos;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WsBackNserioCodifico.dao
{
    public class CustomersDaoImpl : ICustomersInter
    {

        private ExecuteQueryBD _conectionString;
        SqlDataReader dr;

        public CustomersDaoImpl(ExecuteQueryBD conectionString)
        {
            _conectionString = conectionString;
        }


        public List<Customers> devolverTodos()
        {

            List<Customers> list = new List<Customers>();

            string sql = " select * from Sales.Customers ";



            var parametros = new Dictionary<string, object>
            {

            };

            using (SqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                    Customers categorias = new Customers(
    dr.IsDBNull(dr.GetOrdinal("custid")) ? 0 : dr.GetInt32(dr.GetOrdinal("custid")),
    dr.IsDBNull(dr.GetOrdinal("companyname")) ? string.Empty : dr.GetString(dr.GetOrdinal("companyname")),
    dr.IsDBNull(dr.GetOrdinal("contactname")) ? string.Empty : dr.GetString(dr.GetOrdinal("contactname")),
    dr.IsDBNull(dr.GetOrdinal("contacttitle")) ? string.Empty : dr.GetString(dr.GetOrdinal("contacttitle")),
    dr.IsDBNull(dr.GetOrdinal("address")) ? string.Empty : dr.GetString(dr.GetOrdinal("address")),
    dr.IsDBNull(dr.GetOrdinal("city")) ? string.Empty : dr.GetString(dr.GetOrdinal("city")),
    dr.IsDBNull(dr.GetOrdinal("region")) ? string.Empty : dr.GetString(dr.GetOrdinal("region")),
    dr.IsDBNull(dr.GetOrdinal("postalcode")) ? string.Empty : dr.GetString(dr.GetOrdinal("postalcode")),
    dr.IsDBNull(dr.GetOrdinal("country")) ? string.Empty : dr.GetString(dr.GetOrdinal("country")),
    dr.IsDBNull(dr.GetOrdinal("phone")) ? string.Empty : dr.GetString(dr.GetOrdinal("phone")),
    dr.IsDBNull(dr.GetOrdinal("fax")) ? string.Empty : dr.GetString(dr.GetOrdinal("fax"))
);
                    list.Add(categorias);
                }
            }

            return list;
        }

        public List<Customers> devolverFecOrdenPosOrden(int cust,Date fechaOrden,Date fechaPosOrden)
        {

            List<Customers> list = new List<Customers>();

            string sql = " select " +
                " c.custid, " +
                " c.companyname, " +
                " c.contactname, " +
                " c.contacttitle, " +
                " c.address, " +
                " c.city, " +
                " c.region, " +
                " c.postalcode, " +
                " c.country, " +
                " c.phone, " +
                " c.fax " +
                " from Sales.Customers as c " +
                " JOIN Sales.Orders as o on c.custid = o.custid " +
                " Where c.custid = @custid and CAST(o.orderdate AS DATE) = @fechaOrden and CAST(o.Shippeddate AS DATE) = @fechaPosOrden";



            var parametros = new Dictionary<string, object>
            {
                 { "@custid", cust  },
                  { "@fechaOrden", fechaOrden  },
                   { "@fechaPosOrden", fechaPosOrden  }
            };

            using (SqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                    Customers categorias = new Customers(
                        dr.GetInt32(dr.GetOrdinal("custid")),
                        dr.GetString(dr.GetOrdinal("companyname")),
                        dr.GetString(dr.GetOrdinal("contactname")),
                        dr.GetString(dr.GetOrdinal("contacttitle")),
                        dr.GetString(dr.GetOrdinal("address")),
                        dr.GetString(dr.GetOrdinal("city")),
                        dr.GetString(dr.GetOrdinal("region")),
                        dr.GetString(dr.GetOrdinal("postalcode")),
                        dr.GetString(dr.GetOrdinal("country")),
                        dr.GetString(dr.GetOrdinal("phone")),
                        dr.GetString(dr.GetOrdinal("fax"))
                    );
                    list.Add(categorias);
                }
            }

            return list;
        }

        public bool agregarRegistro(Customers datos)
        {
            bool respuesta;
            string sql = "INSERT INTO Sales.Customers " +
                "(companyname, contactname,contacttitle,address," +
                "city,region,postalcode,country,phone,fax ) " +
                "VALUES (@companyname, @contactname,@contacttitle," +
                "@address,@city,@region,@postalcode,@country,@phone,@fax)";
            var parameters = new Dictionary<string, object>
    {
        { "@companyname", datos.companyname  },
        { "@contactname", datos.contactname },
        { "@contacttitle", datos.contacttitle },
        { "@address", datos.address },
        { "@city", datos.city },
        { "@region", datos.region },
        { "@postalcode", datos.postalcode },
        { "@country", datos.country },
        { "@phone", datos.phone },
        { "@fax", datos.fax }
    };

            bool rpt = _conectionString.ExecuteUpdateBd(sql, parameters);
            Console.WriteLine(sql);

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


        public bool actualizarRegistros(Customers datos)
        {
            bool respuesta;
            string sql = "UPDATE Sales.Customers " +
                "SET companyname = @companyname," +
                " contactname = @contactname, " +
                " contacttitle = @contacttitle, " +
                " address = @address, " +
                " city = @city, " +
                " region = @region, " +
                " postalcode = @postalcode, " +
                " country = @country, " +
                " phone = @phone, " +
                " fax = @fax " +
                "WHERE custid = @custid";

            var parameters = new Dictionary<string, object>
    {
                  { "@custid", datos.custid },
        { "@companyname", datos.companyname  },
        { "@contactname", datos.contactname },
        { "@contacttitle", datos.contacttitle },
        { "@address", datos.address },
        { "@city", datos.city },
        { "@region", datos.region },
        { "@postalcode", datos.postalcode },
        { "@country", datos.country },
        { "@phone", datos.phone },
        { "@fax", datos.fax }
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
            string sql = "DELETE FROM Sales.Customers " +
               " WHERE custid = @CategoryId";
            Console.WriteLine(sql);
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

        public Customers buscarRegistroNombre(string datos)
        {
            string sql = " select * from Sales.Customers"
                 + " WHERE companyname = @CategoryN";

            Customers categorias = null;

            var parametros = new Dictionary<string, object>
            {
              { "@CategoryN", datos }
            };

            using (SqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                     categorias = new Customers(
     dr.IsDBNull(dr.GetOrdinal("custid")) ? 0 : dr.GetInt32(dr.GetOrdinal("custid")),
     dr.IsDBNull(dr.GetOrdinal("companyname")) ? string.Empty : dr.GetString(dr.GetOrdinal("companyname")),
     dr.IsDBNull(dr.GetOrdinal("contactname")) ? string.Empty : dr.GetString(dr.GetOrdinal("contactname")),
     dr.IsDBNull(dr.GetOrdinal("contacttitle")) ? string.Empty : dr.GetString(dr.GetOrdinal("contacttitle")),
     dr.IsDBNull(dr.GetOrdinal("address")) ? string.Empty : dr.GetString(dr.GetOrdinal("address")),
     dr.IsDBNull(dr.GetOrdinal("city")) ? string.Empty : dr.GetString(dr.GetOrdinal("city")),
     dr.IsDBNull(dr.GetOrdinal("region")) ? string.Empty : dr.GetString(dr.GetOrdinal("region")),
     dr.IsDBNull(dr.GetOrdinal("postalcode")) ? string.Empty : dr.GetString(dr.GetOrdinal("postalcode")),
     dr.IsDBNull(dr.GetOrdinal("country")) ? string.Empty : dr.GetString(dr.GetOrdinal("country")),
     dr.IsDBNull(dr.GetOrdinal("phone")) ? string.Empty : dr.GetString(dr.GetOrdinal("phone")),
     dr.IsDBNull(dr.GetOrdinal("fax")) ? string.Empty : dr.GetString(dr.GetOrdinal("fax"))
 );

                }
            }

            return categorias;

        }

        public List<Customers> buscarRegistroPorId(int id)
        {

            List<Customers> list = new List<Customers>();

            string sql = " select * from Sales.Customers"
                 + " WHERE custid = @CategoryId";

            Customers categorias = null;

            var parametros = new Dictionary<string, object>
            {
              { "@CategoryId", id }
            };

            using (SqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                     categorias = new Customers(
   dr.IsDBNull(dr.GetOrdinal("custid")) ? 0 : dr.GetInt32(dr.GetOrdinal("custid")),
   dr.IsDBNull(dr.GetOrdinal("companyname")) ? string.Empty : dr.GetString(dr.GetOrdinal("companyname")),
   dr.IsDBNull(dr.GetOrdinal("contactname")) ? string.Empty : dr.GetString(dr.GetOrdinal("contactname")),
   dr.IsDBNull(dr.GetOrdinal("contacttitle")) ? string.Empty : dr.GetString(dr.GetOrdinal("contacttitle")),
   dr.IsDBNull(dr.GetOrdinal("address")) ? string.Empty : dr.GetString(dr.GetOrdinal("address")),
   dr.IsDBNull(dr.GetOrdinal("city")) ? string.Empty : dr.GetString(dr.GetOrdinal("city")),
   dr.IsDBNull(dr.GetOrdinal("region")) ? string.Empty : dr.GetString(dr.GetOrdinal("region")),
   dr.IsDBNull(dr.GetOrdinal("postalcode")) ? string.Empty : dr.GetString(dr.GetOrdinal("postalcode")),
   dr.IsDBNull(dr.GetOrdinal("country")) ? string.Empty : dr.GetString(dr.GetOrdinal("country")),
   dr.IsDBNull(dr.GetOrdinal("phone")) ? string.Empty : dr.GetString(dr.GetOrdinal("phone")),
   dr.IsDBNull(dr.GetOrdinal("fax")) ? string.Empty : dr.GetString(dr.GetOrdinal("fax"))
);
                    list.Add(categorias);
                }
            }

            return list;

        }




        public string buscarNombreRegistroPorId(int id)
        {

            string nombreCliente = "";

            string sql = " select companyname from Sales.Customers"
                 + " WHERE custid = @CategoryId";

            Customers categorias = null;

            var parametros = new Dictionary<string, object>
            {
              { "@CategoryId", id }
            };

            using (SqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {


                    nombreCliente = dr.IsDBNull(dr.GetOrdinal("companyname")) ? string.Empty : dr.GetString(dr.GetOrdinal("companyname"));
 

                   
                }
            }

            return nombreCliente;


        }



    }
}
