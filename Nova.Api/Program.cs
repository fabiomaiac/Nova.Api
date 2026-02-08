using Nova.Application;
using Nova.Domain.Repositories;
using Nova.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Nova.Infra.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Injeção de dependência
builder.Services.AddScoped<IContaBancariaRepository, ContaBancariaRepository>();
builder.Services.AddScoped<ContaService>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite("Data Source=contas.db");
});

var app = builder.Build();


app.MapOpenApi();

app.MapControllers();

app.Run();
