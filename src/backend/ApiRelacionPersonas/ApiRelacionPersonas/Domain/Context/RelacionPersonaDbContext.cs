
using ApiRelacionPersonas.Domain;
using Microsoft.EntityFrameworkCore;

namespace ApiRelacionPersonas.Domain
{
    public class RelacionPersonaDbContext: DbContext
    {
        public RelacionPersonaDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {

        }


        public DbSet<Persona> Personas { get; set; }
        public DbSet<Relacion> Relaciones { get; set; }
        public DbSet<TipoRelacion> TipoRelacions { get; set; }

    }
}
