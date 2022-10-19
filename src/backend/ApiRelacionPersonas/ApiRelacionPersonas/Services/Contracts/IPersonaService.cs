using ApiRelacionPersonas.Domain;

namespace ApiRelacionPersonas.Services
{
    public interface IPersonaService
    {
        IQueryable<Persona> GetAll();
        Task Add(Persona persona);
        Task<bool> Exists(Persona persona);
        Task Edit(Persona persona);
        Task Delete(Persona persona);
        Task<Persona> FindById(int persona);

        Task<int> MaleCount();
        Task<int> FemaleCount();
        Task<double> ArgentinosPercentage();
    }
}
