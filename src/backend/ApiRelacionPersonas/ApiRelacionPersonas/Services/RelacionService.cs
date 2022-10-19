using ApiRelacionPersonas.Domain;
using ApiRelacionPersonas.Services.Constants;
using Microsoft.EntityFrameworkCore;

namespace ApiRelacionPersonas.Services
{
    public class RelacionService: IRelacionService
    {
        private readonly ITipoRelacionManager tipoRelacionManager;
        private readonly IRelacionManager _relacionManager;
        private readonly ILogger<RelacionService> logger;

        public RelacionService(ITipoRelacionManager tipoRelacionManager, IRelacionManager relacionManager, ILogger<RelacionService> logger)
        {
            this.tipoRelacionManager = tipoRelacionManager;
            this._relacionManager = relacionManager;
            this.logger = logger;
        }


        public async Task Add(Relacion relacion)
        {
            try
            {
               
                if (relacion.TipoRelacionId == 0)
                {
                    TipoRelacion tipoRelacion;

                    tipoRelacion = await tipoRelacionManager.Find(x => x.Relacion == ConstantService.TIPO_RELACION_PADRE)
                                        .FirstOrDefaultAsync();

                    relacion.TipoRelacionId = tipoRelacion.Id;
                }

                await _relacionManager.Add(relacion);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message, ex);
                throw new ServiceException("Se produjo un error al dar de alta una nueva relacion");
            }
        }

        public async Task<bool> Exists(int idPadre,int idHijo)
        {
            try
            {
                bool existe = await this._relacionManager.GetAll()
                            .Where(x => x.PersonaId_Padre == idPadre && x.PersonaId_Hijo == idHijo)
                            .AnyAsync();

                
                return existe;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message, ex);
                throw new ServiceException("Se produjo un error al verificar si existe la persona");
            }

        }

        public async Task<Relacion> GetRelacion(int idPadre,int idHijo)
        {
            try
            {
                return await this._relacionManager.Find(x => x.PersonaId_Padre == idPadre && x.PersonaId_Hijo == idHijo)
                  .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message, ex);
                throw new ServiceException("Se produjo un error al traer la relacion");
            }
           
        }
    }
}
