using ApiRelacionPersonas.Domain;
using ApiRelacionPersonas.Services;

namespace ApiRelacionPersonas.Api
{
    public static class ServiceExtensions
    {
        public static void SetDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            
            services.AddTransient<IPersonaService, PersonaService>();           
            services.AddTransient<IRelacionService, RelacionService>();
            services.AddTransient<ITipoRelacionService, TipoRelacionService>();

            services.AddTransient<ITipoRelacionManager, TipoRelacionManager>();
            services.AddTransient<IRelacionManager, RelacionManager>();
            services.AddTransient<IPersonaManager, PersonaManager>();
            
        }

    }
}
