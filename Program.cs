using Api2Postgresql.Context;
using Api2Postgresql.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//  cadena de conexion
var connectionString = builder.Configuration.GetConnectionString("PostgreSqlConnection");
builder.Services.AddDbContext<AutosDbContext>(options =>
    options.UseNpgsql(connectionString));
//  Dependencia interface e implementacion
builder.Services.AddScoped<AutosInterface, AutosRepository>();


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
