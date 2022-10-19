
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApiRelacionPersonas.Domain
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly RelacionPersonaDbContext DbContext;

        public Repository(RelacionPersonaDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Add(T entity)
        {
            DbContext.Set<T>().Add(entity);
        }

        public async Task AddAsync(T entity)
        {
            await DbContext.Set<T>().AddAsync(entity);
        }

        public async void AddChunks(IEnumerable<T> chunks)
        {
            await DbContext.AddRangeAsync(chunks).ConfigureAwait(false);
        }

        public void Delete(T entity)
        {
            DbContext.Set<T>().Remove(entity);
        }

        public void Edit(T entity, Func<T, int> getKey)
        {
            if (entity == null)
            {
                throw new ArgumentException("Cannot add a null entity.");
            }

            var entry = DbContext.Entry<T>(entity);

            if (entry.State == EntityState.Detached)
            {
                var set = DbContext.Set<T>();
                T attachedEntity = set.Find(getKey(entity));

                if (attachedEntity != null)
                {
                    var attachedEntry = DbContext.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(entity);
                }
                else
                {
                    entry.State = EntityState.Modified; // This should attach entity
                }
            }
        }

        public void Edit(IEnumerable<T> chunks)
        {
            DbContext.UpdateRange(chunks);
        }


        public IQueryable<T> Find(Expression<Func<T, bool>> predicate, string includePath = null)
        {
            IQueryable<T> query = DbContext.Set<T>().Where(predicate);

            if (!string.IsNullOrWhiteSpace(includePath))
            {
                query = query.Include(includePath);
            }
            return query;
        }

        public IQueryable<T> GetAll(string includePath = null)
        {
            IQueryable<T> query = DbContext.Set<T>();

            if (!string.IsNullOrWhiteSpace(includePath))
            {
                query = query.Include(includePath);
            }
            return query;
        }

        public void Save()
        {
            DbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await DbContext.SaveChangesAsync();
        }
    }

}
