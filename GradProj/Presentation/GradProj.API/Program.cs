using GradProj.Application;
using GradProj.Application.JwtToken;
using GradProj.Application.ServiceAbs;
using GradProj.Application.ServiceImp;
using GradProj.Infrastructure.Background_Jobs;
using GradProj.Infrastructure.Configurations;
using GradProj.Infrastructure.External_Services.Amazon;
using GradProj.Persistance;
using Hangfire;
using System.Security.Cryptography;
using System.Text.Json.Serialization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;




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
            // Jwt Configirasyon


            var jwtSection = builder.Configuration.GetSection("Jwt");
            var jwtOptions = jwtSection.Get<JwtOptions>();
            var keyString = jwtSection["Key"];
            jwtOptions.Key = new SymmetricSecurityKey(Convert.FromBase64String(keyString));





            builder.Services.AddScoped<IGenerateToken, GenerateToken>();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtOptions.Issuer,
            ValidAudience = jwtOptions.Audience,
            IssuerSigningKey = jwtOptions.Key
        };
    });
            builder.Services.Configure<JwtOptions>(options =>
            {
                options.Issuer = jwtOptions.Issuer;
                options.Audience = jwtOptions.Audience;
                options.ExpireMinutes = jwtOptions.ExpireMinutes;
                options.Key = jwtOptions.Key;
            });
            builder.Services.AddAuthorization();
            /// CORS Config
             builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", policy =>
                {
                    policy.WithOrigins("http://localhost:3000") // Next.js development adresi
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            var app = builder.Build();
            app.UseCors("AllowFrontend");

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
            app.UseAuthentication();

            


            app.MapControllers();

            app.Run();

            
        }
    }
}
