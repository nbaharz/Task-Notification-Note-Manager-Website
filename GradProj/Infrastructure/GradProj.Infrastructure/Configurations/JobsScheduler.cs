using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradProj.Infrastructure.Background_Jobs;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;

namespace GradProj.Infrastructure.Configurations
{
    public static class JobScheduler
    {
        public static void ConfigureJobs(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();

            var jobManager = scope.ServiceProvider.GetRequiredService<IRecurringJobManager>();
            var reminderJob = scope.ServiceProvider.GetRequiredService<ReminderJob>();
            var discountJob = scope.ServiceProvider.GetRequiredService<DiscountCheckJob>();

            jobManager.AddOrUpdate(
                "reminder-check",
                () => reminderJob.ExecuteAsync(),
                Cron.Minutely
            );

            jobManager.AddOrUpdate(
                "discount-check-morning",
                () => discountJob.ExecuteAsync(),
                "0 8 * * *"
            );

            jobManager.AddOrUpdate(
                "discount-check-evening",
                () => discountJob.ExecuteAsync(),
                "46 10 * * *"
            );
        }
    }
}
