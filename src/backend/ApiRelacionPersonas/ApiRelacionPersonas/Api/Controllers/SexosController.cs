using ApiRelacionPersonas.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiRelacionPersonas.Api.Controllers
{
    [ApiController]
    [Route("api/sexos")]
    public class SexosController:ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISexoService _sexoService;
        private readonly ILogger<SexosController> _logger;

        public SexosController(IMapper mapper, ISexoService sexoService, ILogger<SexosController> logger)
        {
            this._mapper = mapper;
            this._sexoService = sexoService;
            this._logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SexoResponseDto>>> Get([FromQuery] PaginationDto paginationDto)
        {
            try
            {
                var listado = _sexoService.GetAll();

                var paginado = await listado.Pagination(paginationDto)
                                            .ToListAsync();

                await HttpContext.InsertParameterPaginationHeader(listado);

                var listadoDto = _mapper.Map<IEnumerable<SexoResponseDto>>(paginado);

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
