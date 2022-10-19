using ApiRelacionPersonas.Domain;
using ApiRelacionPersonas.Services.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ApiRelacionPersonas.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly IPersonaManager _personalManager;
        private readonly ILogger<PersonaService> logger;

        public PersonaService(IPersonaManager personalManager,ILogger<PersonaService> logger)
        {
            _personalManager = personalManager;
            this.logger = logger;           
        }



        public IQueryable<Persona> GetAll()
        {
            try
            {
                return _personalManager.GetAll()
                        .Include(x => x.Nacionalidad)
                        .Include(x => x.Sexo)
                        .Include(x => x.TipoDocumento)
                        .OrderBy(x=> x.Nombre);
                        
            }                
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message, ex);
                throw new ServiceException("Se produjo un error al traer a todas las personas");
            }
        }

        public async Task Add(Persona persona)
        {
            try
            {
                await _personalManager.Add(persona);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message, ex);
                throw new ServiceException("Se produjo un error al dar de alta una nueva persona");
            }
        }

        public async Task<bool> Exists(Persona persona)
        {
            try
            {
                bool existe = await this._personalManager.GetAll()
                        .Where(x => x.TipoDocumentoId == persona.TipoDocumentoId &&
                                   x.NumeroDocumento == persona.NumeroDocumento &&
                                   x.NacionalidadId == persona.NacionalidadId &&
                                   x.SexoId == persona.SexoId)
                        .AnyAsync();
                return existe;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message, ex);
                throw new ServiceException("Se produjo un error al verificar si existe la persona");
            }
                                
        }

        public async Task Edit(Persona persona)
        {
            try
            {
                await this._personalManager.Edit(persona);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message, ex);
                throw new ServiceException("Se produjo un error al editar la persona");
            }
        }

        public async Task Delete(Persona persona)
        {
            try
            {
                await this._personalManager.Delete(persona);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message, ex);
                throw new ServiceException("Se produjo un error al eliminar la persona");
            }
        }

        public async Task<Persona> FindById(int id)
        {
            try
            {
                return await this._personalManager.Find(x => x.Id == id)
                            .Include(x => x.Nacionalidad)
                            .Include(x => x.Sexo)
                            .Include(x => x.TipoDocumento)
                            .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message, ex);
                throw new ServiceException("Se produjo un error al buscar la persona");
            }
        }

        public async Task<int> MaleCount()
        {
            try
            {
                return await this._personalManager.GetAll()
                             .Include(x => x.Sexo)
                             .Where(x => x.Sexo.Nombre == ConstantService.TIPO_SEXO_MASCULINO)
                             .CountAsync();
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message, ex);
                throw new ServiceException("Se produjo un error al contar la cantidad de personas masculinas");
            }
        }
        public async Task<int> FemaleCount()
        {
            try
            {
                return await this._personalManager.GetAll()
                             .Include(x => x.Sexo)
                             .Where(x => x.Sexo.Nombre == ConstantService.TIPO_SEXO_FEMENINO)
                             .CountAsync();
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message, ex);
                throw new ServiceException("Se produjo un error al contar la cantidad de personas femeninas");
            }
        }

        public async Task<double> ArgentinosPercentage()
        {
            try
            {
               int cantidadArgentinos=await this._personalManager.GetAll()
                             .Include(x => x.Nacionalidad)
                             .Where(x => x.Nacionalidad.Nombre == ConstantService.TIPO_NACIONALIDAD_ARGENTINO)
                             .CountAsync();
               int total = await this._personalManager.GetAll()
                                .CountAsync();


                return cantidadArgentinos * 100 / total;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message, ex);
                throw new ServiceException("Se produjo un error al traer el porcentaje de personas Argentinas");
            }
        }
    }
}
