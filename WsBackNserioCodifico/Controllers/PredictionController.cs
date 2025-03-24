using Microsoft.AspNetCore.Mvc;
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
    }
}
