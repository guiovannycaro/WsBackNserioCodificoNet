using BacktecnoFactApi.Infraestructura.Util;
using System.Data.SqlClient;
using System.Text.Json;
using WsBackNserioCodifico.interfaces;
using WsBackNserioCodifico.Modelos;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WsBackNserioCodifico.dao
{
    public class ShippersDaoImpl : IShippersInter
    {

        private ExecuteQueryBD _conectionString;
        SqlDataReader dr;

        public ShippersDaoImpl(ExecuteQueryBD conectionString)
        {
            _conectionString = conectionString;
        }


        public List<Shippers> devolverTodos()
        {

            List<Shippers> list = new List<Shippers>();

            string sql = " select * from Sales.Shippers";



            var parametros = new Dictionary<string, object>
            {

            };

            using (SqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                    Shippers categorias = new Shippers(
                        dr.GetInt32(dr.GetOrdinal("shipperid")),
                        dr.GetString(dr.GetOrdinal("companyname")),
                        dr.GetString(dr.GetOrdinal("phone"))
                    );
                    list.Add(categorias);
                }
            }

            return list;
        }


        public bool agregarRegistro(Shippers datos)
        {
            bool respuesta;
            string sql = "INSERT INTO Sales.Shippers " +
                "(companyname, phone) " +
                "VALUES (@companyname, @phone)";
            var parameters = new Dictionary<string, object>
    {
        { "@companyname", datos.companyname },
        { "@phone", datos.phone }
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


        public bool actualizarRegistros(Shippers datos)
        {
            bool respuesta;
            string sql = "UPDATE Sales.Shippers " +
                "SET companyname = @companyname, phone = @phone " +
                "WHERE shipperid = @shipperid";

            var parameters = new Dictionary<string, object>
    {
        { "@shipperid", datos.shipperid },
       { "@companyname", datos.companyname },
        { "@phone", datos.phone }
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
            string sql = "DELETE FROM Sales.Shippers " +
               " WHERE shipperid = @shipperid";

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

        public Shippers buscarRegistroNombre(string datos)
        {
            string sql = " select * from Sales.Shippers"
                 + " WHERE companyname = @CategoryN";

            Shippers categorias = null;

            var parametros = new Dictionary<string, object>
            {
              { "@CategoryN", datos }
            };

            using (SqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                    categorias = new Shippers(
                         dr.GetInt32(dr.GetOrdinal("shipperid")),
                        dr.GetString(dr.GetOrdinal("companyname")),
                        dr.GetString(dr.GetOrdinal("phone"))
                   );

                }
            }

            return categorias;

        }

        public List<Shippers> buscarRegistroPorId(int id)
        {

            List<Shippers> list = new List<Shippers>();
            string sql = " select * from Sales.Shippers"
                 + " WHERE shipperid = @CategoryId";

            Shippers categorias = null;

            var parametros = new Dictionary<string, object>
            {
              { "@CategoryId", id }
            };

            using (SqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                     categorias = new Shippers(
                        dr.GetInt32(dr.GetOrdinal("shipperid")),
                        dr.GetString(dr.GetOrdinal("companyname")),
                        dr.GetString(dr.GetOrdinal("phone"))
                    );
                    list.Add(categorias);
                }
            }

            return list;

        }


 }
}
