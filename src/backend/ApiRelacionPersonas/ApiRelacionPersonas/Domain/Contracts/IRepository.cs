using System.Linq.Expressions;

namespace ApiRelacionPersonas.Domain
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll(string includePath = null);
        IQueryable<T> Find(Expression<Func<T, bool>> predicate, string includePath = null);
        void Add(T entity);
        Task AddAsync(T entity);
        void AddChunks(IEnumerable<T> chunks);
        void Delete(T entity);
        void Edit(T entity, Func<T, int> getKey);

        void Edit(IEnumerable<T> chunks);
        void Save();

        Task SaveAsync();


    }
}
