using BacktecnoFactApi.Infraestructura.Util;
using System.Data.SqlClient;
using System.Text.Json;
using WsBackNserioCodifico.interfaces;
using WsBackNserioCodifico.Modelos;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WsBackNserioCodifico.dao
{
    public class CategoriesDaoImpl : ICategoriesInter
    {

        private ExecuteQueryBD _conectionString;
        SqlDataReader dr;

        public CategoriesDaoImpl(ExecuteQueryBD conectionString)
        {
            _conectionString = conectionString;
        }


        public List<Categories> devolverTodos()
        {

            List<Categories> list = new List<Categories>();

            string sql = " select * from Production.Categories";



            var parametros = new Dictionary<string, object>
            {

            };

            using (SqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                    Categories categorias = new Categories(
                        dr.GetInt32(dr.GetOrdinal("categoryid")),
                        dr.GetString(dr.GetOrdinal("categoryname")),
                        dr.GetString(dr.GetOrdinal("description"))
                    );
                    list.Add(categorias);
                }
            }

            return list;
        }


        public bool agregarRegistro(Categories datos)
        {
            bool respuesta;
            string sql = "INSERT INTO Production.Categories (categoryname, description) " +
                "VALUES (@Name, @Descripcion)";
            var parameters = new Dictionary<string, object>
    {
        { "@Name", datos.categoryname },
        { "@Descripcion", datos.description }
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


        public bool actualizarRegistros(Categories datos)
        {
            bool respuesta;
            string sql = "UPDATE Production.Categories " +
                "SET categoryname = @Name, description = @Descripcion " +
                "WHERE categoryid = @CategoryId";

            var parameters = new Dictionary<string, object>
    {
        { "@CategoryId", datos.categoryid },
        { "@Name", datos.categoryname },
        { "@Descripcion", datos.description }
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
            string sql = "DELETE FROM Production.Categories " +
               " WHERE categoryid = @CategoryId";

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

        public Categories buscarRegistroNombre(string datos)
        {
            string sql = " select * from Production.Categories"
                 + " WHERE categoryname = @CategoryN";

            Categories categorias = null;

            var parametros = new Dictionary<string, object>
            {
              { "@CategoryN", datos }
            };

            using (SqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                    categorias = new Categories(
                       dr.GetInt32(dr.GetOrdinal("categoryid")),
                       dr.GetString(dr.GetOrdinal("categoryname")),
                       dr.GetString(dr.GetOrdinal("description"))
                   );

                }
            }

            return categorias;

        }

        public List<Categories> buscarRegistroPorId(int id)
        {

            List<Categories> list = new List<Categories>();

            string sql = " select * from Production.Categories"
                 + " WHERE categoryid = @CategoryId"; 

            Categories categorias = null;

            var parametros = new Dictionary<string, object>
            {
              { "@CategoryId", id }
            };

            using (SqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                     categorias = new Categories(
                        dr.GetInt32(dr.GetOrdinal("categoryid")),
                        dr.GetString(dr.GetOrdinal("categoryname")),
                        dr.GetString(dr.GetOrdinal("description"))
                    );
                    list.Add(categorias);
                }
            }

            return list;

        }


 }
}
