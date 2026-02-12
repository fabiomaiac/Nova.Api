using Nova.Application;
using Nova.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Nova.Infra.Data;
using Nova.Domain.Interfaces.Repositories;
using Nova.Domain.Interfaces.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Injeção de dependência
builder.Services.AddScoped<IContaBancariaRepository, ContaBancariaRepository>();
builder.Services.AddScoped<IContaService, ContaService>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite("Data Source=contas.db");
});

var app = builder.Build();


app.MapOpenApi();

app.MapControllers();

app.Run();
