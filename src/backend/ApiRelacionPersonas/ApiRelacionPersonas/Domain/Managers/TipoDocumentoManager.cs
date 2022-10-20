using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRelacionPersonas.Domain
{
    public class TipoDocumentoManager : ITipoDocumentoManager
    {
        private readonly IRepository<TipoDocumento> _repository;

        public TipoDocumentoManager(IRepository<TipoDocumento> repository)
        {
            this._repository = repository;
        }
        public IQueryable<TipoDocumento> GetAll()
        {
            return this._repository.GetAll();
        }
    }
}
