using ApiRelacionPersonas.Domain;

namespace ApiRelacionPersonas.Services
{
    public class SexoService : ISexoService
    {
        private readonly ISexoManager _sexoManager;
        private readonly ILogger<Sexo> _logger;

        public SexoService(ISexoManager sexoManager,ILogger<Sexo> logger)
        {
            this._sexoManager = sexoManager;
            this._logger = logger;
        }
        public IQueryable<Sexo> GetAll()
        {
            try
            {
                return _sexoManager.GetAll();

            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message, ex);
                throw new ServiceException("Se produjo un error al traer los sexos");
            }
        }
    }
}
