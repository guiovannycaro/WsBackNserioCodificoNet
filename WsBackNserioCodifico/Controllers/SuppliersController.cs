using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WsBackNserioCodifico.dao;
using WsBackNserioCodifico.Modelos;
using static Azure.Core.HttpHeader;

namespace WsBackNserioCodifico.Controllers
{

    [Route("nserio/AppAdmin/Suppliers/")]
    [ApiController]
    public class SuppliersController : Controller
    {

        private readonly SuppliersDaoImpl _servicio;

        public SuppliersController(SuppliersDaoImpl servicio)
        {
            _servicio = servicio;
        }

        [HttpGet("ListarSuppliers")]
        public IActionResult listaSuppliers()
        {
            try
            {
                var categories =  _servicio.devolverTodos();

            if (categories == null || !categories.Any())
            {
              
                return NotFound(new Respuesta
                {
                    StatusCode = 404,
                    Message = "error",
                    Description = "La base de datos está vacía."
                });

            }
            return Ok( categories);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new Respuesta
                {
                    StatusCode = 500,
                    Message = "error",
                    Description = "Error al obtener los registros"
                });
            }
        }


        [HttpPost("InsertarSuppliers")]
        public IActionResult CreateSuppliers(Suppliers datos)
        {
            try
            {
                bool respuesta = _servicio.agregarRegistro(datos);

                if (respuesta) {
                    return Ok(new Respuesta
                    {
                        StatusCode = 200,
                        Message = "success",
                        Description = "Registro insertado correctamente.",
                    });
                }
                else {
                    return StatusCode(500,new Respuesta
                    {
                        StatusCode = 500,
                        Message = "error",
                        Description = "Registro no insertada correctamente.",
                    });

                }
            }
            catch (SqlException ex)
            {
                return StatusCode(400, new Respuesta
                {
                    StatusCode = 400,
                    Message = "error",
                    Description = "Error al insertar el registro"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Respuesta
                {
                    StatusCode = 500,
                    Message = "error",
                    Description = "Error interno al insertar el registro"
                });
            }
        }


        [HttpPost("UpdateSuppliers")]
        public IActionResult UpdateShippers(Suppliers datos)
        {
            try
            {
                bool respuesta = _servicio.actualizarRegistros(datos);

                if (respuesta)
                {
                    return Ok(new Respuesta
                    {
                        StatusCode = 200,
                        Message = "success",
                        Description = "Registro actualizado correctamente.",
                    });
                }
                else
                {
                    return StatusCode(500, new Respuesta
                    {
                        StatusCode = 500,
                        Message = "error",
                        Description = "Registro no actualizado correctamente.",
                    });

                }
            }
            catch (SqlException ex)
            {
                return StatusCode(400, new Respuesta
                {
                    StatusCode = 400,
                    Message = "error",
                    Description = "Error al actualizar  el registro"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Respuesta
                {
                    StatusCode = 500,
                    Message = "error",
                    Description = "Error interno al actualizar el registro"
                });
            }
        }

        [HttpDelete("DeleteSuppliers")]
        public IActionResult DeleteSuppliers([FromQuery] int dato)
        {
            bool respuesta;
            Console.WriteLine("Suppliers a eliminar " + dato);
            try
            {
                var cat = _servicio.buscarRegistroPorId(dato);
                if (cat == null)
                {
                    return NotFound(new Respuesta
                    {
                        StatusCode = 404,
                        Message = "error",
                        Description = "Verifica el ID ingresado."
                    });
                }


                respuesta = _servicio.eliminarRegistro(dato);
                if (respuesta)
                {
                    return Ok(new Respuesta
                    {
                        StatusCode = 200,
                        Message = "success",
                        Description = "El registro fue eliminado exitosamente."
                    });
                }
                else {
                    return StatusCode(500, new Respuesta
                    {
                        StatusCode = 500,
                        Message = "error",
                        Description = "Registro no eliminado correctamente.",
                    });
                }
            }
            catch (SqlException ex)
            {
                return StatusCode(400, new Respuesta
                {
                    StatusCode = 400,
                    Message = "error",
                    Description = "Error al eliminar el registro"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Respuesta
                {
                    StatusCode = 500,
                    Message = "error",
                    Description = "Error interno al eliminar el registro"
                });
            }
        }

        [HttpGet("BuscarSuppliersById")]
        public IActionResult findSuppliersById([FromQuery] int dato)
        {
            try
            {
                var categories = _servicio.buscarRegistroPorId(dato);

                if (categories == null )
                {

                    return NotFound(new Respuesta
                    {
                        StatusCode = 404,
                        Message = "error",
                        Description = "El registro no esta en la base de datos."
                    });

                }
                return Ok(categories);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new Respuesta
                {
                    StatusCode = 500,
                    Message = "error",
                    Description = "Error al obtener el registro"
                });
            }
        }


        [HttpGet("BuscarSuppliersByName")]
        public IActionResult findSuppliersByName([FromQuery] string dato)
        {
            try
            {
                var categories = _servicio.buscarRegistroNombre(dato);

                if (categories == null)
                {

                    return NotFound(new Respuesta
                    {
                        StatusCode = 404,
                        Message = "error",
                        Description = "El registro no esta en la base de datos."
                    });

                }
                return Ok(categories);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new Respuesta
                {
                    StatusCode = 500,
                    Message = "error",
                    Description = "Error al obtener el registro"
                });
            }
        }

    }
}
