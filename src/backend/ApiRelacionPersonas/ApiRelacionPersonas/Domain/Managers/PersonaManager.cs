using ApiRelacionPersonas.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApiRelacionPersonas.Domain
{
    public class PersonaManager : IPersonaManager
    {
        private IRepository<Persona> _repository;
        public PersonaManager(IRepository<Persona> repository)
        {
            this._repository = repository;
        }
        public async Task Add(Persona entity)
        {
             await this._repository.AddAsync(entity);
             await this._repository.SaveAsync();
        }

       
        public async Task Delete(Persona entity)
        {
            this._repository.Delete(entity);
            await this._repository.SaveAsync();
        }

        public async Task Edit(Persona entity)
        {
            this._repository.Edit(entity,persona=>persona.Id);

            await this._repository.SaveAsync();
        }

    

        public  IQueryable<Persona> GetAll()
        {
            return this._repository.GetAll();
        }

        public IQueryable<Persona> Find(Expression<Func<Persona, bool>> predicate)
        {
            return this._repository.Find(predicate);
        }

        public async Task<double> Count()=>await this._repository.GetAll()
                                                                 .CountAsync();

        
       

    }
}
