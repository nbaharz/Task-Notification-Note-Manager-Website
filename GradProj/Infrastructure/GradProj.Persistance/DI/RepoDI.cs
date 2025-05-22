using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradProj.Persistance.RepositoryImp;
using GradProj.Domain.RepositoryAbs;
using Microsoft.Extensions.DependencyInjection;

namespace GradProj.Persistance.DI
{
    public static class RepoDI
    {
        public static void Init(IServiceCollection services)
        {
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IGoalRepository, GoalRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IReminderRepository, ReminderRepository>();
            services.AddScoped<IToDoRepository, TodoRepository>();
            services.AddScoped<ITrackedProductsRepository, TrackedProductsRepository>();
            services.AddScoped<IUserEventRepository, UserEventRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserTaskRepository, UserTaskRepository>();
            services.AddScoped<IUserTrackedProductsRepository, UserTrackedProductsRepository>();

        }
    }
}
