using ApiRelacionPersonas.Domain;
using ApiRelacionPersonas.Services;
using ApiRelacionPersonas.Services.Constants;
using Microsoft.AspNetCore.Mvc;

namespace ApiRelacionPersonas.Api.Controllers
{
    [ApiController]
    [Route("api/relaciones")]
    public class RelacionesController: ControllerBase
    {
        private readonly IRelacionService _relacionService;
        private readonly ITipoRelacionService _tipoRelacionService;

        public RelacionesController(IRelacionService relacionService,ITipoRelacionService tipoRelacionService)
        {
            this._relacionService = relacionService;
            this._tipoRelacionService = tipoRelacionService;
        }


        [HttpGet("{id1:int}/{id2:int}")]
        public async Task<ActionResult<string>> Get(int id1,int id2)
        {
            try
            {
                var relacion = await _relacionService.GetRelacion(id1,id2);

                if (relacion == null)
                    return NotFound();

                //var personaDto = _mapper.Map<PersonaResponseDto>(persona);
                var result = $"Existe una relacion pero solo se pueden notificar las relaciones(" +
                              $"{ConstantService.TIPO_RELACION_HERMANX},{ConstantService.TIPO_RELACION_PADRE},{ConstantService.TIPO_RELACION_TIX})";


                TipoRelacion tipoRelacion = await this._tipoRelacionService.Find(relacion.TipoRelacionId);

                if (tipoRelacion.Relacion == ConstantService.TIPO_RELACION_PADRE)
                    return NotFound(result);

                
                return Ok(tipoRelacion.Relacion);
            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                //this.logger.LogError(ex.Message, ex);
                return BadRequest("Se produjo un error inesperado");
            }
        }

    }
}
