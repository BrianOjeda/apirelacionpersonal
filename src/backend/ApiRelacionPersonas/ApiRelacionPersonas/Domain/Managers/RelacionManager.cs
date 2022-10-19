using System.Linq.Expressions;

namespace ApiRelacionPersonas.Domain
{
    public class RelacionManager:IRelacionManager
    {
        private readonly IRepository<Relacion> _repository;

        public RelacionManager(IRepository<Relacion> repository) 
        {
            this._repository = repository;
        }

        public async Task Add(Relacion entity)
        {
            await this._repository.AddAsync(entity);
            await this._repository.SaveAsync();
        }

        public IQueryable<Relacion> GetAll()
        {
            return this._repository.GetAll();
        }

        public IQueryable<Relacion> Find(Expression<Func<Relacion, bool>> predicate)
        {
            return this._repository.Find(predicate);
        }



    }
}
