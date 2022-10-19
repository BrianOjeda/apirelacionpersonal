
using ApiRelacionPersonas.Domain;
using ApiRelacionPersonas.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ApiRelacionPersonas.Api
{
    [ApiController]
    [Route("api/personas")]
    public class PersonasController: ControllerBase
    {        
        private readonly IMapper _mapper;
        private readonly ILogger<PersonasController> logger;
        private readonly IRelacionService _relacionService;
        private readonly IPersonaService _personaService;
        public PersonasController(IPersonaService personaService,
                                  IMapper mapper,
                                  ILogger<PersonasController> logger,
                                  IRelacionService relacionService)
        {
            this._personaService = personaService;
            this._mapper = mapper;
            this.logger = logger;
            this._relacionService = relacionService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonaResponseDto>>> Get([FromQuery] PaginationDto paginationDto)
        {
            try
            {
                var listado = _personaService.GetAll();

                var paginado=await listado.Pagination(paginationDto)
                                          .ToListAsync();

                await HttpContext.InsertParameterPaginationHeader(listado);

                var listadoDto = _mapper.Map<IEnumerable<PersonaResponseDto>>(paginado);

                return Ok(listadoDto);

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


        [HttpGet("{id:int}")]
        public async Task<ActionResult<PersonaResponseDto>> Get(int id)
        {
            try
            {
                var persona = await _personaService.FindById(id);

                if (persona == null)
                    return NotFound();

                var personaDto = _mapper.Map<PersonaResponseDto>(persona);

                return Ok(personaDto);
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

        [HttpPost]
        public async Task<ActionResult> Post(PersonaInsertRequestDto personaDto)
        {
            try
            {
                var persona = _mapper.Map<Persona>(personaDto);

                var existe = await this._personaService.Exists(persona);

                if (existe)
                    return BadRequest("La persona ya existe");


                await this._personaService.Add(persona);

                return Ok();
            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                this.logger.LogError(ex.Message, ex);
                return BadRequest("Se produjo un error inesperado");
            }
        }

        [HttpPut("{id:int}")] //api/personas/1
        public async Task<ActionResult> Put(PersonaUpdateRequestDto personaDto,int id)
        {
            try
            {
                var persona = _mapper.Map<Persona>(personaDto);

                if (persona.Id != id)
                    return BadRequest("El Id de la persona no coincide con el Id de la URL");


                Persona aux = await this._personaService.FindById(persona.Id);

                if (aux == null)
                    return NotFound();


                await this._personaService.Edit(persona);

                return Ok();
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

        [HttpDelete("{id:int}")] //api/personas/1
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Persona aux = await this._personaService.FindById(id);

                if (aux == null)
                    return NotFound();


                await this._personaService.Delete(aux);

                return Ok();
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

        [HttpPost]
        [Route("{id1:int}/padre/{id2:int}")]//api/personas/1/padre/2
        [Route("{id1:int}/padre/{id2:int}/{idRelacion:int?}")]//api/personas/1/padre/2/1
        public async Task<ActionResult> Post([FromRoute] int id1,int id2,int? idRelacion=0)
        {
            try
            {                
                var existe = await this._relacionService.Exists(id1,id2);

                if (existe)
                    return BadRequest("La relacion ya existe");



                Relacion relacion = new Relacion()
                {
                    PersonaId_Padre = id1,
                    PersonaId_Hijo = id2,
                    TipoRelacionId = (int)idRelacion
                };

                await this._relacionService.Add(relacion);

                return Ok();
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
