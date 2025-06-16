using GradProj.Application;
using GradProj.Application.ServiceAbs;
using GradProj.Application.ServiceImp;
using GradProj.Infrastructure.Background_Jobs;
using GradProj.Infrastructure.Configurations;
using GradProj.Infrastructure.External_Services.Amazon;
using GradProj.Persistance;
using Hangfire;
using System.Text.Json.Serialization;

namespace GradProj.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // We add this section
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.RegisterAllServices();
            builder.Services.AddControllers()
             .AddJsonOptions(options =>
             {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
             });

            //Hangfire config we add this
            builder.Services.AddHangfireWithMySql(builder.Configuration);

            // ---- Servis ve job kayýtlarý (bunu baska dosyaya alabiliriz) ----
            builder.Services.AddScoped<ReminderJob>();
            builder.Services.AddScoped<DiscountCheckJob>();
            //-------------------------------
           
            //Amazon isDiscounted method denemesi icin
            builder.Services.AddScoped<AmazonProductService>();
            //....................
            builder.Services.AddSignalR();

            var app = builder.Build();

            JobScheduler.ConfigureJobs(app.Services);

            // Hangfire dashboard (opsiyonel)
            app.UseHangfireDashboard();
            app.MapControllers();
            //------

            app.MapHub<NotificationHub>("/hubs/notification");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();

            
        }
    }
}
