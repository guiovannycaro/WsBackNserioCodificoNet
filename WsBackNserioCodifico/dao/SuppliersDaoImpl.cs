using BacktecnoFactApi.Infraestructura.Util;
using System.Data.SqlClient;
using System.Text.Json;
using WsBackNserioCodifico.interfaces;
using WsBackNserioCodifico.Modelos;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WsBackNserioCodifico.dao
{
    public class SuppliersDaoImpl : ISuppliersInter
    {

        private ExecuteQueryBD _conectionString;
        SqlDataReader dr;

        public SuppliersDaoImpl(ExecuteQueryBD conectionString)
        {
            _conectionString = conectionString;
        }


        public List<Suppliers> devolverTodos()
        {

            List<Suppliers> list = new List<Suppliers>();

            string sql = " select * from Production.Suppliers ";



            var parametros = new Dictionary<string, object>
            {

            };

            using (SqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                    Suppliers categorias = new Suppliers(
     dr.IsDBNull(dr.GetOrdinal("supplierid")) ? 0 : dr.GetInt32(dr.GetOrdinal("supplierid")),
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


        public bool agregarRegistro(Suppliers datos)
        {
            bool respuesta;
            string sql = "INSERT INTO Production.Suppliers " +
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


        public bool actualizarRegistros(Suppliers datos)
        {
            bool respuesta;
            string sql = "UPDATE Production.Suppliers " +
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
                "WHERE supplierid = @supplierid";

            var parameters = new Dictionary<string, object>
    {
                  { "@supplierid", datos.supplierid },
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
            string sql = "DELETE FROM Production.Suppliers " +
               " WHERE supplierid = @CategoryId";

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

        public Suppliers buscarRegistroNombre(string datos)
        {
            string sql = " select * from Production.Suppliers"
                 + " WHERE companyname = @CategoryN";

            Suppliers categorias = null;

            var parametros = new Dictionary<string, object>
            {
              { "@CategoryN", datos }
            };

            using (SqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                     categorias = new Suppliers(
   dr.IsDBNull(dr.GetOrdinal("supplierid")) ? 0 : dr.GetInt32(dr.GetOrdinal("supplierid")),
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

        public List<Suppliers> buscarRegistroPorId(int id)
        {

            List<Suppliers> list = new List<Suppliers>();
            string sql = " select * from Production.Suppliers"
                 + " WHERE supplierid = @CategoryId";

            Suppliers categorias = null;

            var parametros = new Dictionary<string, object>
            {
              { "@CategoryId", id }
            };

            using (SqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                    categorias = new Suppliers(
 dr.IsDBNull(dr.GetOrdinal("supplierid")) ? 0 : dr.GetInt32(dr.GetOrdinal("supplierid")),
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

      
    }
}
