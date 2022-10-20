using ApiRelacionPersonas.Domain;

namespace ApiRelacionPersonas.Services
{
    public interface INacionalidadService
    {
        IQueryable<Nacionalidad> GetAll();
    }
}
