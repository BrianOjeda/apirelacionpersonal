using ApiRelacionPersonas.Domain;

namespace ApiRelacionPersonas.Services
{
    public interface ISexoService
    {
        IQueryable<Sexo> GetAll();
    }
}
