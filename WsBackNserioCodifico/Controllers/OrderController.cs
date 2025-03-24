using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WsBackNserioCodifico.dao;
using WsBackNserioCodifico.Modelos;
using static Azure.Core.HttpHeader;

namespace WsBackNserioCodifico.Controllers
{

    [Route("nserio/AppAdmin/Orders/")]
    [ApiController]
    public class OrderController : Controller
    {

        private readonly OrdersDaoImpl _servicio;

        public OrderController(OrdersDaoImpl servicio)
        {
            _servicio = servicio;
        }

        [HttpGet("ListarOrders")]
        public IActionResult listaOrders()
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


        [HttpPost("InsertarOrders")]
        public IActionResult CreateCategory(Orders datos)
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


        [HttpPost("UpdateOrders")]
        public IActionResult UpdateCategory(Orders datos)
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

        [HttpDelete("DeleteOrders")]
        public IActionResult DeleteCategory([FromQuery] int dato)
        {
            bool respuesta;
            Console.WriteLine("registro a eliminar " + dato);
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

        [HttpGet("BuscarOrdersById")]
        public IActionResult findOrdersById([FromQuery] int dato)
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


        [HttpGet("BuscarOrdersByName")]
        public IActionResult findOrdersByName([FromQuery] string dato)
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


        [HttpGet("BuscarOrdersCustomersById")]
        public IActionResult buscarOrdersCustomersById([FromQuery] int dato)
        {
            try
            {
                var categories = _servicio.buscarRegistroPorCustomerId(dato);

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
