using System.Linq.Expressions;

namespace ApiRelacionPersonas.Domain
{
    public interface IRelacionManager
    {
        Task Add(Relacion entity);
        IQueryable<Relacion> GetAll();
        IQueryable<Relacion> Find(Expression<Func<Relacion, bool>> predicate);
    }
}
