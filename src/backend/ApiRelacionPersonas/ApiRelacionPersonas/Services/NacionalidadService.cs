using ApiRelacionPersonas.Domain;

namespace ApiRelacionPersonas.Services
{
    public class NacionalidadService : INacionalidadService
    {
        private readonly INacionalidadManager _nacionalidadManager;
        private readonly ILogger<NacionalidadService> _logger;

        public NacionalidadService(INacionalidadManager nacionalidadManager,ILogger<NacionalidadService> logger)
        {
            this._nacionalidadManager = nacionalidadManager;
            this._logger = logger;
        }
        public IQueryable<Nacionalidad> GetAll()
        {
            try
            {
                return _nacionalidadManager.GetAll();

            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message, ex);
                throw new ServiceException("Se produjo un error al traer a todas las nacionalidades");
            }
        }
    }
}
