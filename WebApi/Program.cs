using Application.Heroes;
using Domain.Heroes;
using Infrastructure;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Heroes;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

{
    // Dbcontext
    builder.Services.AddDbContext<AppDbContext>(opt =>
    {
        opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });

    builder.Services.AddControllers();

    // Repositories
    builder.Services.AddScoped<IHeroesRepository, HeroesRepository>();

    // Use cases
    builder.Services.AddScoped<GetHeroesUseCase>();


    builder.Services.AddCors(opt =>
    {
        opt.AddDefaultPolicy(policy =>
        {
            policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
    });
}


var app = builder.Build();
{
    app.UseCors();

    app.MapControllers();

    app.Run();
}
