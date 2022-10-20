using ApiRelacionPersonas.Domain;

namespace ApiRelacionPersonas.Services
{
    public interface ITipoDocumentoService
    {
        IQueryable<TipoDocumento> GetAll();
    }
}
