using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradProj.Application.ServiceAbs;
using GradProj.Application.ServiceImp;
using Microsoft.Extensions.DependencyInjection;

namespace GradProj.Application.DI
{
    public static class ServiceDI
    {
        public static void Init(IServiceCollection services)
        {
            // DbContext konfigürasyonu

            // Repository konfigürasyonu

            services.AddScoped<IEventService,EventService>();
            services.AddScoped<IGoalService, GoalService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IReminderService,ReminderService>();
            services.AddScoped<IToDoService, ToDoService>();
            services.AddScoped<ITrackedProductsService,TrackedProductsService>();
            services.AddScoped<IUserEventService,UserEventService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserTaskService,UserTaskService>();
            services.AddScoped<IUserTrackedProductsService, UserTrackedProductsService>();
            services.AddScoped<INoteService, NoteService>();
            // Diğer servis konfigürasyonları burada yapılabilir
        }
    }
}
