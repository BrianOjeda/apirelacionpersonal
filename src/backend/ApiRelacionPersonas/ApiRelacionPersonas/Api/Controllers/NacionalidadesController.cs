using ApiRelacionPersonas.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiRelacionPersonas.Api.Controllers
{
    [ApiController]
    [Route("api/nacionalidades")]
    public class NacionalidadesController:ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly INacionalidadService _nacionalidadService;
        private readonly ILogger<NacionalidadesController> _logger;

        public NacionalidadesController(IMapper mapper,INacionalidadService nacionalidadService,ILogger<NacionalidadesController> logger)
        {
            this._mapper = mapper;
            this._nacionalidadService = nacionalidadService;
            this._logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NacionalidadResponseDto>>> Get([FromQuery] PaginationDto paginationDto)
        {
            try
            {
                var listado = _nacionalidadService.GetAll();

                var paginado = await listado.Pagination(paginationDto)
                                            .ToListAsync();

                await HttpContext.InsertParameterPaginationHeader(listado);

                var listadoDto = _mapper.Map<IEnumerable<NacionalidadResponseDto>>(paginado);

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
