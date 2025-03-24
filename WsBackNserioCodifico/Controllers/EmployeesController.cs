using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WsBackNserioCodifico.dao;
using WsBackNserioCodifico.Modelos;
using static Azure.Core.HttpHeader;

namespace WsBackNserioCodifico.Controllers
{

    [Route("nserio/AppAdmin/Employees/")]
    [ApiController]
    public class EmployeesController : Controller
    {

        private readonly EmployeesDaoImpl _servicio;

        public EmployeesController(EmployeesDaoImpl servicio)
        {
            _servicio = servicio;
        }

        [HttpGet("ListarEmployees")]
        public IActionResult listaEmployees()
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


        [HttpPost("InsertarEmployees")]
        public IActionResult CreateCategory(Employees datos)
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


        [HttpPost("UpdateEmployees")]
        public IActionResult UpdateCategory(Employees datos)
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

        [HttpDelete("DeleteEmployees")]
        public IActionResult DeleteCategory([FromQuery] int dato)
        {
            bool respuesta;
            Console.WriteLine("category a eliminar " + dato);
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

        [HttpGet("BuscarEmployeesById")]
        public IActionResult findCategoriasById([FromQuery] int dato)
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


        [HttpGet("BuscarEmployeesByName")]
        public IActionResult findCategoriasByName([FromQuery] string dato)
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
