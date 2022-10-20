using ApiRelacionPersonas.Domain;

namespace ApiRelacionPersonas.Services
{
    public class TipoDocumentoService : ITipoDocumentoService
    {
        private readonly ITipoDocumentoManager _tipoDocumentoManager;
        private readonly ILogger<TipoDocumentoService> _logger;

        public TipoDocumentoService(ITipoDocumentoManager tipoDocumentoManager,ILogger<TipoDocumentoService> logger)
        {
            this._tipoDocumentoManager = tipoDocumentoManager;
            this._logger = logger;
        }
        public IQueryable<TipoDocumento> GetAll()
        {
            try
            {
                return _tipoDocumentoManager.GetAll();

            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message, ex);
                throw new ServiceException("Se produjo un error al traer todos los tipos de documentos");
            }
        }
    }
}
