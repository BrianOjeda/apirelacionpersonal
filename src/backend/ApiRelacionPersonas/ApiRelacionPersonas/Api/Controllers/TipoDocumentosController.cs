using ApiRelacionPersonas.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiRelacionPersonas.Api.Controllers
{
    [ApiController]
    [Route("api/tipodocumentos")]
    public class TipoDocumentosController:ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITipoDocumentoService _tipoDocumentoService;
        private readonly ILogger<TipoDocumentosController> _logger;

        public TipoDocumentosController(IMapper mapper, ITipoDocumentoService tipoDocumentoService, ILogger<TipoDocumentosController> logger)
        {
            this._mapper = mapper;
            this._tipoDocumentoService = tipoDocumentoService;
            this._logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoDocumentoResponseDto>>> Get([FromQuery] PaginationDto paginationDto)
        {
            try
            {
                var listado = _tipoDocumentoService.GetAll();

                var paginado = await listado.Pagination(paginationDto)
                                            .ToListAsync();

                await HttpContext.InsertParameterPaginationHeader(listado);

                var listadoDto = _mapper.Map<IEnumerable<TipoDocumentoResponseDto>>(paginado);

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
