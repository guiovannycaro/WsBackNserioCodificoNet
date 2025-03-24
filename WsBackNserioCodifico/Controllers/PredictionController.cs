using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WsBackNserioCodifico.dao;
using WsBackNserioCodifico.Modelos;

namespace WsBackNserioCodifico.Controllers
{
    [Route("nserio/AppAdmin/Prediction/")]
    [ApiController]
    public class PredictionController : Controller
    {

        private readonly PredictionsDaoImpl _servicio;

        public PredictionController(PredictionsDaoImpl servicio)
        {
            _servicio = servicio;
        }

        [HttpGet("ListarPrediction")]
        public IActionResult listaPredictions()
        {
            try
            {
                var categories = _servicio.devolverTodos();

                if (categories == null || !categories.Any())
                {

                    return NotFound(new Respuesta
                    {
                        StatusCode = 404,
                        Message = "error",
                        Description = "La base de datos está vacía."
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
                    Description = "Error al obtener los registros"
                });
            }
        }


        [HttpPost("createNewOrdenDetails")]
        public IActionResult createNewOrdenDetails(NOrderDetail datos)
        {
            try
            {
                bool respuesta = _servicio.agregarRegistro(datos);

                if (respuesta)
                {
                    return Ok(new Respuesta
                    {
                        StatusCode = 200,
                        Message = "success",
                        Description = "Registro insertado correctamente.",
                    });
                }
                else
                {
                    return StatusCode(500, new Respuesta
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


    }
}
