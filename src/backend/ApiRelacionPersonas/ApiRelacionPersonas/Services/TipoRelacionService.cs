using ApiRelacionPersonas.Domain;
using Microsoft.EntityFrameworkCore;

namespace ApiRelacionPersonas.Services
{
    public class TipoRelacionService: ITipoRelacionService
    {
        private readonly ITipoRelacionManager _tipoRelacionManager;
        private readonly ILogger<TipoRelacionService> _logger;

        public TipoRelacionService(ITipoRelacionManager tipoRelacionManager,ILogger<TipoRelacionService> logger)
        {
            this._tipoRelacionManager = tipoRelacionManager;
            this._logger = logger;
        }

        public async Task<TipoRelacion> Find(int id)
        {
            try
            {
                return await this._tipoRelacionManager
                                 .Find(x => x.Id == id)
                                 .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message, ex);
                throw new ServiceException("Se produjo un error al traer el tipo de relacion");
            }
            
        }

        public IQueryable<TipoRelacion> GetAll()
        {
            try
            {
                return _tipoRelacionManager.GetAll();

            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message, ex);
                throw new ServiceException("Se produjo un error al traer los tipos de relaciones");
            }
        }
    }
}
