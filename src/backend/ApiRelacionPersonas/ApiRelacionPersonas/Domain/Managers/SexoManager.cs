using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRelacionPersonas.Domain
{
    public class SexoManager : ISexoManager
    {
        private readonly IRepository<Sexo> _repository;

        public SexoManager(IRepository<Sexo> repository)
        {
            this._repository = repository;
        }
        public IQueryable<Sexo> GetAll()
        {
            return this._repository.GetAll();
        }

        
    }
}
