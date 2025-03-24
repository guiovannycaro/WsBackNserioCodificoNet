using BacktecnoFactApi.Infraestructura.Util;
using System.Data.SqlClient;
using System.Text.Json;
using WsBackNserioCodifico.interfaces;
using WsBackNserioCodifico.Modelos;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WsBackNserioCodifico.dao
{
    public class EmployeesDaoImpl : IEmployeesInter
    {

        private ExecuteQueryBD _conectionString;
        SqlDataReader dr;

        public EmployeesDaoImpl(ExecuteQueryBD conectionString)
        {
            _conectionString = conectionString;
        }


        public List<Employees> devolverTodos()
        {

            List<Employees> list = new List<Employees>();

            string sql = " select * from HR.Employees";



            var parametros = new Dictionary<string, object>
            {

            };

            using (SqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                    Employees categorias = new Employees(
    dr.IsDBNull(dr.GetOrdinal("empid")) ? 0 : dr.GetInt32(dr.GetOrdinal("empid")),
    dr.IsDBNull(dr.GetOrdinal("lastname")) ? string.Empty : dr.GetString(dr.GetOrdinal("lastname")),
    dr.IsDBNull(dr.GetOrdinal("firstname")) ? string.Empty : dr.GetString(dr.GetOrdinal("firstname")),
    dr.IsDBNull(dr.GetOrdinal("title")) ? string.Empty : dr.GetString(dr.GetOrdinal("title")),
    dr.IsDBNull(dr.GetOrdinal("titleofcourtesy")) ? string.Empty : dr.GetString(dr.GetOrdinal("titleofcourtesy")),
    dr.IsDBNull(dr.GetOrdinal("birthdate")) ? DateTime.MinValue : dr.GetDateTime(dr.GetOrdinal("birthdate")),
    dr.IsDBNull(dr.GetOrdinal("hiredate")) ? DateTime.MinValue : dr.GetDateTime(dr.GetOrdinal("hiredate")),
    dr.IsDBNull(dr.GetOrdinal("address")) ? string.Empty : dr.GetString(dr.GetOrdinal("address")),
    dr.IsDBNull(dr.GetOrdinal("city")) ? string.Empty : dr.GetString(dr.GetOrdinal("city")),
    dr.IsDBNull(dr.GetOrdinal("region")) ? string.Empty : dr.GetString(dr.GetOrdinal("region")),
    dr.IsDBNull(dr.GetOrdinal("postalcode")) ? string.Empty : dr.GetString(dr.GetOrdinal("postalcode")),
    dr.IsDBNull(dr.GetOrdinal("country")) ? string.Empty : dr.GetString(dr.GetOrdinal("country")),
    dr.IsDBNull(dr.GetOrdinal("phone")) ? string.Empty : dr.GetString(dr.GetOrdinal("phone")),
    dr.IsDBNull(dr.GetOrdinal("mgrid")) ? 0 : dr.GetInt32(dr.GetOrdinal("mgrid"))
);
                    list.Add(categorias);
                }
            }

            return list;
        }


        public bool agregarRegistro(Employees datos)
        {
            bool respuesta;
            try
            {
                // Intentar convertir las fechas a DateTime
                DateTime birthdate;
                DateTime hiredate;

                if (!DateTime.TryParse(datos.birthdate.ToString(), out birthdate) || birthdate > DateTime.Now)
                {
                    Console.WriteLine("Fecha de nacimiento inválida. Usando la fecha actual.");
                    birthdate = DateTime.Now;
                }

                if (!DateTime.TryParse(datos.hiredate.ToString(), out hiredate))
                {
                    Console.WriteLine("Fecha de contratación inválida. Usando la fecha actual.");
                    hiredate = DateTime.Now;
                }

                Console.WriteLine("Fecha de nacimiento recibida: " + birthdate);
                Console.WriteLine("Fecha de contratación recibida: " + hiredate);

                string sql = "INSERT INTO HR.Employees " +
                    "(lastname, firstname, title, titleofcourtesy, " +
                    "birthdate, hiredate, address, city, region, postalcode, " +
                    "country, phone, mgrid) " +
                    "VALUES (@lastname, @firstname, @title, @titleofcourtesy, " +
                    "@birthdate, @hiredate, @address, @city, @region, @postalcode, " +
                    "@country, @phone, @mgrid)";

                var parameters = new Dictionary<string, object>
        {
            { "@lastname", datos.lastname },
            { "@firstname", datos.firstname },
            { "@title", datos.title },
            { "@titleofcourtesy", datos.titleofcourtesy },
            { "@birthdate", birthdate },
            { "@hiredate", hiredate },
            { "@address", datos.address },
            { "@city", datos.city },
            { "@region", datos.region },
            { "@postalcode", datos.postalcode },
            { "@country", datos.country },
            { "@phone", datos.phone },
            { "@mgrid", datos.mgrid }
        };

                bool rpt = _conectionString.ExecuteUpdateBd(sql, parameters);
                respuesta = rpt;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar el registro: " + ex.Message);
                respuesta = false;
            }

            return respuesta;
        }


        public bool actualizarRegistros(Employees datos)
        {
            bool respuesta;
            string sql = "UPDATE HR.Employees " +
                "SET lastname = @lastname," +
                " firstname = @firstname, " +
                " title = @title, " +
                " titleofcourtesy = @titleofcourtesy, " +
                " birthdate = @birthdate, " +
                " hiredate = @hiredate, " +
                " address = @address, " +
                " city = @city, " +
                " region = @region, " +
                " postalcode = @postalcode, " +
                 " country = @country, " +
                " phone = @phone, " +
                " mgrid = @mgrid " +
                "WHERE empid = @empid";

            var parameters = new Dictionary<string, object>
    {
                  { "@empid", datos.empid  },
            { "@lastname", datos.lastname  },
        { "@firstname", datos.firstname },
        { "@title", datos.title },
        { "@titleofcourtesy", datos.titleofcourtesy },
        { "@birthdate", datos.birthdate },
        { "@hiredate", datos.hiredate },
        { "@address", datos.address },
        { "@city", datos.city },
        { "@region", datos.region },
        { "@postalcode", datos.postalcode },
        { "@country", datos.country },
        { "@phone", datos.phone },
        { "@mgrid", datos.mgrid }
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
            string sql = "DELETE FROM HR.Employees " +
               " WHERE empid = @CategoryId";

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

        public Employees buscarRegistroNombre(string datos)
        {
            string sql = " select * from HR.Employees"
                 + " WHERE companyname = @CategoryN";

            Employees categorias = null;

            var parametros = new Dictionary<string, object>
            {
              { "@CategoryN", datos }
            };

            using (SqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                    categorias = new Employees(
     dr.IsDBNull(dr.GetOrdinal("empid")) ? 0 : dr.GetInt32(dr.GetOrdinal("empid")),
     dr.IsDBNull(dr.GetOrdinal("lastname")) ? string.Empty : dr.GetString(dr.GetOrdinal("lastname")),
     dr.IsDBNull(dr.GetOrdinal("firstname")) ? string.Empty : dr.GetString(dr.GetOrdinal("firstname")),
     dr.IsDBNull(dr.GetOrdinal("title")) ? string.Empty : dr.GetString(dr.GetOrdinal("title")),
     dr.IsDBNull(dr.GetOrdinal("titleofcourtesy")) ? string.Empty : dr.GetString(dr.GetOrdinal("titleofcourtesy")),
     dr.IsDBNull(dr.GetOrdinal("birthdate")) ? DateTime.MinValue : dr.GetDateTime(dr.GetOrdinal("birthdate")),
     dr.IsDBNull(dr.GetOrdinal("hiredate")) ? DateTime.MinValue : dr.GetDateTime(dr.GetOrdinal("hiredate")),
     dr.IsDBNull(dr.GetOrdinal("address")) ? string.Empty : dr.GetString(dr.GetOrdinal("address")),
     dr.IsDBNull(dr.GetOrdinal("city")) ? string.Empty : dr.GetString(dr.GetOrdinal("city")),
     dr.IsDBNull(dr.GetOrdinal("region")) ? string.Empty : dr.GetString(dr.GetOrdinal("region")),
     dr.IsDBNull(dr.GetOrdinal("postalcode")) ? string.Empty : dr.GetString(dr.GetOrdinal("postalcode")),
     dr.IsDBNull(dr.GetOrdinal("country")) ? string.Empty : dr.GetString(dr.GetOrdinal("country")),
     dr.IsDBNull(dr.GetOrdinal("phone")) ? string.Empty : dr.GetString(dr.GetOrdinal("phone")),
     dr.IsDBNull(dr.GetOrdinal("mgrid")) ? 0 : dr.GetInt32(dr.GetOrdinal("mgrid"))
 );

                }
            }

            return categorias;

        }

        public List<Employees> buscarRegistroPorId(int id)
        {

            List<Employees> list = new List<Employees>();
            string sql = " select * from HR.Employees"
                 + " WHERE empid = @CategoryId";

            Employees categorias = null;

            var parametros = new Dictionary<string, object>
            {
              { "@CategoryId", id }
            };

            using (SqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                     categorias = new Employees(
     dr.IsDBNull(dr.GetOrdinal("empid")) ? 0 : dr.GetInt32(dr.GetOrdinal("empid")),
     dr.IsDBNull(dr.GetOrdinal("lastname")) ? string.Empty : dr.GetString(dr.GetOrdinal("lastname")),
     dr.IsDBNull(dr.GetOrdinal("firstname")) ? string.Empty : dr.GetString(dr.GetOrdinal("firstname")),
     dr.IsDBNull(dr.GetOrdinal("title")) ? string.Empty : dr.GetString(dr.GetOrdinal("title")),
     dr.IsDBNull(dr.GetOrdinal("titleofcourtesy")) ? string.Empty : dr.GetString(dr.GetOrdinal("titleofcourtesy")),
     dr.IsDBNull(dr.GetOrdinal("birthdate")) ? DateTime.MinValue : dr.GetDateTime(dr.GetOrdinal("birthdate")),
     dr.IsDBNull(dr.GetOrdinal("hiredate")) ? DateTime.MinValue : dr.GetDateTime(dr.GetOrdinal("hiredate")),
     dr.IsDBNull(dr.GetOrdinal("address")) ? string.Empty : dr.GetString(dr.GetOrdinal("address")),
     dr.IsDBNull(dr.GetOrdinal("city")) ? string.Empty : dr.GetString(dr.GetOrdinal("city")),
     dr.IsDBNull(dr.GetOrdinal("region")) ? string.Empty : dr.GetString(dr.GetOrdinal("region")),
     dr.IsDBNull(dr.GetOrdinal("postalcode")) ? string.Empty : dr.GetString(dr.GetOrdinal("postalcode")),
     dr.IsDBNull(dr.GetOrdinal("country")) ? string.Empty : dr.GetString(dr.GetOrdinal("country")),
     dr.IsDBNull(dr.GetOrdinal("phone")) ? string.Empty : dr.GetString(dr.GetOrdinal("phone")),
     dr.IsDBNull(dr.GetOrdinal("mgrid")) ? 0 : dr.GetInt32(dr.GetOrdinal("mgrid"))
 );
                    list.Add(categorias);
                }
            }

            return list;

        }

      
    }
}
