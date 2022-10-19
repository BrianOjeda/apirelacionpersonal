using ApiRelacionPersonas.Domain;
using System.Linq.Expressions;

namespace ApiRelacionPersonas.Domain
{
    public class TipoRelacionManager: ITipoRelacionManager
    { 

         private IRepository<TipoRelacion> _repository;
        public TipoRelacionManager(IRepository<TipoRelacion> repository)
        {
            this._repository = repository;
        }

        public IQueryable<TipoRelacion> Find(Expression<Func<TipoRelacion, bool>> predicate)
        {
            return this._repository.Find(predicate);
        }

        public IQueryable<TipoRelacion> GetAll()
        {
            return this._repository.GetAll();
        }
    }
}
