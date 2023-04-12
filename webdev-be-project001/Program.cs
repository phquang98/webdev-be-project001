using Microsoft.EntityFrameworkCore;

using webdev_be_project001;
using webdev_be_project001.Data;
using webdev_be_project001.Interfaces;
using webdev_be_project001.Repositories;

var builder = WebApplication.CreateBuilder(args);

// --- Add DI
builder.Services.AddTransient<Seed>();
builder.Services.AddScoped<IPokemonRepo, PokemonRepo>();

// --- Add services

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataCtx>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// --- Initialize the app
var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seed>();
        service.SeedDataContext();
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

// --- Start

app.Run();
