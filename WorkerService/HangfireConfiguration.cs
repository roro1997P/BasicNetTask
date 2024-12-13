using Application.Heroes;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerJobs.Heroes;

namespace WorkerService
{
    public static class HangfireConfiguration
    {
        public static void AddHangfireServices(this IServiceCollection services, string connectionString)
        {
            services.AddHangfire(config =>
            {
                config.UseSqlServerStorage(connectionString);
            });
            services.AddHangfireServer();
        }

        public static void ConfigureJobs(IRecurringJobManager recurringJobManager, IServiceProvider serviceProvider)
        {
            var heroSyncJob = serviceProvider.GetRequiredService<HeroSyncJob>();

            recurringJobManager.AddOrUpdate(
                "HeroSyncJob",
                () => heroSyncJob.Execute(),
                Cron.Hourly
            );
        }
    }
}
