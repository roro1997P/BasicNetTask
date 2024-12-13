using Application.Heroes;
using Domain.Heroes;
using Hangfire;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Heroes;
using Microsoft.EntityFrameworkCore;
using WorkerJobs.Heroes;
using WorkerService;

var builder = Host.CreateDefaultBuilder(args)
        .ConfigureLogging(logging =>
        {
            logging.ClearProviders();
            logging.AddConsole();
            logging.AddDebug();
        })
        .ConfigureServices((context, services) =>
        {
            // Hangfire configuration
            services.AddHangfireServices(context.Configuration.GetConnectionString("DefaultConnection"));

            // Dbcontext
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection"));
            });

            // Repositories
            services.AddScoped<IHeroesRepository, HeroesRepository>();

            // Use cases
            services.AddScoped<FetchHeroesUseCase>();
            services.AddScoped<UpsertHeroUseCase>();
            services.AddScoped<SyncHeroesUseCase>();

            // Jobs
            services.AddScoped<HeroSyncJob>();

            // Http client
            services.AddHttpClient<FetchHeroesUseCase>(client =>
            {
                client.BaseAddress = new Uri("https://gateway.marvel.com/v1/public/");
            });
        });



var host = builder.Build();

using (var scope = host.Services.CreateScope())
{
    var recurringManager = scope.ServiceProvider.GetRequiredService<IRecurringJobManager>();
    HangfireConfiguration.ConfigureJobs(recurringManager, scope.ServiceProvider);
}

host.Run();
