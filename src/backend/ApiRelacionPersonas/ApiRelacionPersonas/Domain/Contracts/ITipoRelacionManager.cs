using System.Linq.Expressions;

namespace ApiRelacionPersonas.Domain
{
    public interface ITipoRelacionManager
    {
        IQueryable<TipoRelacion> Find(Expression<Func<TipoRelacion, bool>> predicate);
        IQueryable<TipoRelacion> GetAll();
    }
}
