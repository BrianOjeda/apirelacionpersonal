using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRelacionPersonas.Domain
{
    public interface INacionalidadManager
    {
        IQueryable<Nacionalidad> GetAll();
    }
}
