using GradProj.Application.DI;
using GradProj.Infrastructure.External_Services.DI;
using GradProj.Persistance.DI;

namespace GradProj.API
{
    public static class DependencyInjection
    {
        public static void RegisterAllServices(this IServiceCollection services)
        {
            ServiceDI.Init(services); 
            RepoDI.Init(services);
            ExternalDI.Init(services);
        }
    }
}

