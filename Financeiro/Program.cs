using Cadastro.Services;
using Financeiro.Consumer;
using Financeiro.Context;
using Financeiro.Repositories;
using Financeiro.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FinanceiroContext>(opt => opt.UseSqlite(builder.Configuration.GetConnectionString("Tec")));
builder.Services.AddTransient<IMensageria, Mensageria>();
builder.Services.AddScoped<IPagamentoRepository, PagamentoRepository>();
//builder.Services.AddHostedService<ProcessMessageConsumer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/* app.UseHttpsRedirection(); */
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
