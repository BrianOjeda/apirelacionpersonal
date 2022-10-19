
using System.Linq.Expressions;

namespace ApiRelacionPersonas.Domain
{
    public interface IPersonaManager
    {
        IQueryable<Persona> GetAll();
        Task Add(Persona persona);
        Task Delete(Persona entity);
        Task Edit(Persona entity);
        IQueryable<Persona> Find(Expression<Func<Persona, bool>> predicate);

        Task<double> Count();
    }
}
