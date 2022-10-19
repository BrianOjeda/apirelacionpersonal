using ApiRelacionPersonas.Domain;

namespace ApiRelacionPersonas.Services
{
    public interface IRelacionService
    {
        Task Add(Relacion relacion);
        Task<bool> Exists(int idPadre, int idHijo);
        Task<Relacion> GetRelacion(int idPadre, int idHijo);
    }
}
