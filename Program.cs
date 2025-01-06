using Microsoft.EntityFrameworkCore;
using OficinaAPI.connection;
using OficinaAPI.InfraEstrutura;
using OficinaAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddTransient<iClienteRepository, ClienteRepository>();
builder.Services.AddTransient<iVeiculoRepository, VeiculoRepository>();

builder.Services.AddDbContext<OficinaContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("OficinaDB")));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
