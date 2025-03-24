using BacktecnoFactApi.Infraestructura.Util;
using System.Data.SqlClient;
using System.Text.Json;
using WsBackNserioCodifico.interfaces;
using WsBackNserioCodifico.Modelos;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WsBackNserioCodifico.dao
{
    public class ProductsDaoImpl : IProductsInter
    {

        private ExecuteQueryBD _conectionString;
        SqlDataReader dr;

        public ProductsDaoImpl(ExecuteQueryBD conectionString)
        {
            _conectionString = conectionString;
        }


        public List<Products> devolverTodos()
        {

            List<Products> list = new List<Products>();

            string sql = " select * from Production.Products ";



            var parametros = new Dictionary<string, object>
            {

            };

            using (SqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                    Products categorias = new Products(
    dr.IsDBNull(dr.GetOrdinal("productid")) ? 0 : dr.GetInt32(dr.GetOrdinal("productid")),
    dr.IsDBNull(dr.GetOrdinal("productname")) ? string.Empty : dr.GetString(dr.GetOrdinal("productname")),
    dr.IsDBNull(dr.GetOrdinal("supplierid")) ? 0 : dr.GetInt32(dr.GetOrdinal("supplierid")),
    dr.IsDBNull(dr.GetOrdinal("categoryid")) ? 0 : dr.GetInt32(dr.GetOrdinal("categoryid")),
    dr.IsDBNull(dr.GetOrdinal("unitprice")) ? 0m : dr.GetDecimal(dr.GetOrdinal("unitprice")),
    !dr.IsDBNull(dr.GetOrdinal("discontinued")) && dr.GetBoolean(dr.GetOrdinal("discontinued"))
);
                    list.Add(categorias);
                }
            }

            return list;
        }


        public bool agregarRegistro(Products datos)
        {
            bool respuesta;
            string sql = "INSERT INTO Production.Products" +
                " (productname, supplierid,categoryid,unitprice,discontinued) " +
                "VALUES (@productname, @supplierid,@categoryid,@unitprice,@discontinued)";
            var parameters = new Dictionary<string, object>
    {
        { "@productname", datos.productname },
        { "@supplierid", datos.supplierid },
        { "@categoryid", datos.categoryid },
        { "@unitprice", datos.unitprice }, 
        { "@discontinued", datos.discontinued }
        

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


        public bool actualizarRegistros(Products datos)
        {
            bool respuesta;
            string sql = "UPDATE Production.Products " +
                "SET productname = @productname, " +
                "supplierid = @supplierid, " +
                 "categoryid = @categoryid, " +
                 "unitprice = @unitprice, " +
                  "discontinued = @discontinued " +
                "WHERE productid = @productid";

            var parameters = new Dictionary<string, object>
    {
        { "@productid", datos.productid },
        { "@productname", datos.productname },
        { "@supplierid", datos.supplierid },
        { "@categoryid", datos.categoryid },
        { "@unitprice", datos.unitprice },
        { "@discontinued", datos.discontinued }
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
            string sql = "DELETE FROM Production.Products " +
               " WHERE productid = @CategoryId";

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

        public Products buscarRegistroNombre(string datos)
        {
            string sql = " select * from Production.Products"
                 + " WHERE productname = @CategoryN";

            Products categorias = null;

            var parametros = new Dictionary<string, object>
            {
              { "@CategoryN", datos }
            };

            using (SqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                     categorias = new Products(
  dr.IsDBNull(dr.GetOrdinal("productid")) ? 0 : dr.GetInt32(dr.GetOrdinal("productid")),
  dr.IsDBNull(dr.GetOrdinal("productname")) ? string.Empty : dr.GetString(dr.GetOrdinal("productname")),
  dr.IsDBNull(dr.GetOrdinal("supplierid")) ? 0 : dr.GetInt32(dr.GetOrdinal("supplierid")),
  dr.IsDBNull(dr.GetOrdinal("categoryid")) ? 0 : dr.GetInt32(dr.GetOrdinal("categoryid")),
  dr.IsDBNull(dr.GetOrdinal("unitprice")) ? 0m : dr.GetDecimal(dr.GetOrdinal("unitprice")),
  !dr.IsDBNull(dr.GetOrdinal("discontinued")) && dr.GetBoolean(dr.GetOrdinal("discontinued"))
);

                }
            }

            return categorias;

        }

        public List<Products> buscarRegistroPorId(int id)
        {

            List<Products> list = new List<Products>();
            string sql = " select * from Production.Products"
                 + " WHERE productid = @CategoryId";

            Products categorias = null;

            var parametros = new Dictionary<string, object>
            {
              { "@CategoryId", id }
            };

            using (SqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                     categorias = new Products(
  dr.IsDBNull(dr.GetOrdinal("productid")) ? 0 : dr.GetInt32(dr.GetOrdinal("productid")),
  dr.IsDBNull(dr.GetOrdinal("productname")) ? string.Empty : dr.GetString(dr.GetOrdinal("productname")),
  dr.IsDBNull(dr.GetOrdinal("supplierid")) ? 0 : dr.GetInt32(dr.GetOrdinal("supplierid")),
  dr.IsDBNull(dr.GetOrdinal("categoryid")) ? 0 : dr.GetInt32(dr.GetOrdinal("categoryid")),
  dr.IsDBNull(dr.GetOrdinal("unitprice")) ? 0m : dr.GetDecimal(dr.GetOrdinal("unitprice")),
  !dr.IsDBNull(dr.GetOrdinal("discontinued")) && dr.GetBoolean(dr.GetOrdinal("discontinued"))
);
                    list.Add(categorias);
                }
            }

            return list;

        }


 }
}
