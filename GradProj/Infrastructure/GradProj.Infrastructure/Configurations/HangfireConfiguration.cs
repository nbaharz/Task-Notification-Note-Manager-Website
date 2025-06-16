using Hangfire;
using Hangfire.MySql;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace GradProj.Infrastructure.Configurations
{
    public static class HangfireConfiguration
    {
        public static void AddHangfireWithMySql(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHangfire(config =>
             config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
           .UseSimpleAssemblyNameTypeSerializer()
           .UseRecommendedSerializerSettings()
           .UseStorage(
               new MySqlStorage(
                   configuration.GetConnectionString("DefaultConnection"),
                   new MySqlStorageOptions()
               )
           )
 );

            services.AddHangfireServer();

        }
    }

}
