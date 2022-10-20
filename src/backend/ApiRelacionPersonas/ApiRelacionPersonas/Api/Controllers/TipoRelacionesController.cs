using ApiRelacionPersonas.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiRelacionPersonas.Api.Controllers
{
    [ApiController]
    [Route("api/tiporelaciones")]
    public class TipoRelacionesController : ControllerBase
    {
        private readonly ITipoRelacionService _tipoRelacionService;
        private readonly IMapper _mapper;
        private readonly ILogger<TipoRelacionesController> _logger;

        public TipoRelacionesController(ITipoRelacionService tipoRelacionService, IMapper mapper, ILogger<TipoRelacionesController> logger)
        {
            this._tipoRelacionService = tipoRelacionService;
            this._mapper = mapper;
            this._logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoRelacionResponseDto>>> Get([FromQuery] PaginationDto paginationDto)
        {
            try
            {
                var listado = _tipoRelacionService.GetAll();

                var paginado = await listado.Pagination(paginationDto)
                                            .ToListAsync();

                await HttpContext.InsertParameterPaginationHeader(listado);

                var listadoDto = _mapper.Map<IEnumerable<TipoRelacionResponseDto>>(paginado);

                return Ok(listadoDto);

            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message, ex);
                return BadRequest("Se produjo un error inesperado");
            }
        }
    }
}
