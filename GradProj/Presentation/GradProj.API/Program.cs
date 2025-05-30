using GradProj.Infrastructure.External_Services.Amazon;
using GradProj.Persistance;
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

            //Amazon isDiscounted method denemesi icin
            builder.Services.AddScoped<AmazonProductService>();
            //....................

            var app = builder.Build();

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
