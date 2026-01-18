using Application.Interfaces.Generic_Repository;
using Infrastructure.Data;
using Infrastructure.GenericRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// 2. Obtener la cadena de conexi�n del archivo de configuracion (appsettings.json)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// 3. Registrar el DbContext en el contenedor de servicios
builder.Services.AddDbContext<AppDBContextEcomerce>(options =>
{
    // Usamos el motodo de extension UseNpgsql y le pasamos la cadena de conexi�n.
    options.UseNpgsql(connectionString);
});





builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));


// Add services to the container.

builder.Services.AddControllers();
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
