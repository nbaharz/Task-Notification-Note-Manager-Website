using GradProj.Application;

using GradProj.Application.ServiceAbs;
using GradProj.Application.ServiceImp;
using GradProj.Infrastructure.External_Services.Mailkit;
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
using System.Text;
using GradProj.Application.DI;
using GradProj.Infrastructure.External_Services.Sender;




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
            // Token generator service ekliyoruz
            builder.Services.AddScoped<ITokenGenerator, TokenGenerator>();
            // Mail gönderici service ekliyoruz
            builder.Services.AddScoped<ISender, MailSender>();
            // MailKit service ekliyoruz
            builder.Services.AddScoped<IMailKitService, MailKitService>();
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
            builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                var accessToken = context.Request.Query["access_token"];

                // SignalR endpoint ise ve access token varsa, context'e ata
                var path = context.HttpContext.Request.Path;
                if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/hubs/notification"))
                {
                    context.Token = accessToken;
                }

                return Task.CompletedTask;
            }
        };
    });

            builder.Services.AddAuthorization();


            /// CORS Config
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", policy =>
                {
                    policy.WithOrigins("http://localhost:3000")  // Next.js development adresi
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials();
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

            app.UseAuthentication();
            app.UseAuthorization();





            app.MapControllers();

            app.Run();

            
        }
    }
}
