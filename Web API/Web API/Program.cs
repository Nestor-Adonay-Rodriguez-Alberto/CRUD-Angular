using Microsoft.EntityFrameworkCore;
using Web_API.Handlers.Empleados.Interfaces;
using Web_API.Handlers.Empleados.Repositories;
using Web_API.Models.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// CONTROLADORES DE Endponits:
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

// INYECCION DE LA DB:
builder.Services.AddDbContext<MyDBcontext>(options => options.UseSqlServer(builder.Configuration["ConexionDB"]));

// INYECCION DE LOS REPOSITORY:
builder.Services.AddScoped<IEmpleado, EmpleadoRepository>();


// Habilitando CORS:
builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("NuevaPolitica");
app.UseAuthorization();

app.MapControllers();

app.Run();
