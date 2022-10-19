using ApiRelacionPersonas.Domain;

namespace ApiRelacionPersonas.Services
{
    public interface ITipoRelacionService
    {
        Task<TipoRelacion> Find(int id);
    }
}
