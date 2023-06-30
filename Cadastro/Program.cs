using Cadastro.Context;
using Cadastro.Repositories;
using Cadastro.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.AddDbContext<CadastroContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("Test")));
// builder.Services.AddDbContext<CadastroContext>(opt => opt.UseInMemoryDatabase("TestInMemory"));
builder.Services.AddDbContext<CadastroContext>(opt => opt.UseSqlite(builder.Configuration.GetConnectionString("Tec")));
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IMensageria, Mensageria>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
