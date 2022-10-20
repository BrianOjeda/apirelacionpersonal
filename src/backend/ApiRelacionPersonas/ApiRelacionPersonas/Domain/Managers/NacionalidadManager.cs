using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRelacionPersonas.Domain
{
    public class NacionalidadManager:INacionalidadManager
    {
        private readonly IRepository<Nacionalidad> _repository;

        public NacionalidadManager(IRepository<Nacionalidad> repository)
        {
            this._repository = repository;
        }

        public IQueryable<Nacionalidad> GetAll()
        {
            return this._repository.GetAll();
        }
    }
}
