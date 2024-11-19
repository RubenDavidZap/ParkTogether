using Microsoft.EntityFrameworkCore;
using ParkTogether.DAL;
using ParkTogether.Domain.Interfaces;
using ParkTogether.Domain.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//conexioncon la base de Datos
builder.Services.AddDbContext<DateBaseContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//Contenedor de dependencias
builder.Services.AddScoped<IEmployeeService, EmployeeService>(); 

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
