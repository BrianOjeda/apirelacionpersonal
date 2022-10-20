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
            services.AddTransient<ISexoService, SexoService>();
            services.AddTransient<ITipoDocumentoService, TipoDocumentoService>();
            services.AddTransient<INacionalidadService, NacionalidadService>();

            services.AddTransient<ITipoRelacionManager, TipoRelacionManager>();
            services.AddTransient<IRelacionManager, RelacionManager>();
            services.AddTransient<IPersonaManager, PersonaManager>();
            services.AddTransient<ITipoRelacionManager, TipoRelacionManager>();
            services.AddTransient<ITipoDocumentoManager, TipoDocumentoManager>();
            services.AddTransient<ISexoManager, SexoManager>();
            services.AddTransient<INacionalidadManager, NacionalidadManager>();

        }

    }
}
