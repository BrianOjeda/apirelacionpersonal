using ApiRelacionPersonas.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiRelacionPersonas.Api
{
    [ApiController]
    [Route("api/estadisticas")]
    public class EstadisticasController : ControllerBase
    {
        private readonly IPersonaService _personaService;
        private readonly ILogger<EstadisticasController> logger;

        public EstadisticasController(IPersonaService personaService,ILogger<EstadisticasController> logger)
        {
            this._personaService = personaService;            
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<PersonasEstadisticaResponseDto>> Get()
        {
            try
            {
                var  masculinos= await _personaService.MaleCount();
                var femeninos = await _personaService.FemaleCount();
                var argentinos = await _personaService.ArgentinosPercentage();


                PersonasEstadisticaResponseDto response = new PersonasEstadisticaResponseDto()
                {
                    Cantidad_Hombres = masculinos,
                    Cantidad_Mujeres = femeninos,
                    Porcentaje_Argentinos = int.Parse(argentinos.ToString())
                };

                return Ok(response);
            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message, ex);
                return BadRequest("Se produjo un error inesperado");
            }
        }
    }
}
