// --- Importaciones Necesarias ---
using Microsoft.EntityFrameworkCore;
// Asegúrate de que este 'using' coincida con el namespace de tu proyecto y la carpeta Models
using LAB04_MuñozHerrera.Models; 
using LAB04_MuñozHerrera.Repositories;

var builder = WebApplication.CreateBuilder(args);

// 1. Obtener la cadena de conexión del archivo appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. Registrar el DbContext en el contenedor de dependencias.
builder.Services.AddDbContext<TiendadbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


// 3. Agregar el soporte para Controladores de API.
builder.Services.AddControllers();

// 4. Configurar Swagger para la documentación de la API.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Habilitar Swagger solo en el entorno de desarrollo.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Indicarle a la aplicación que use las rutas definidas en los Controladores.
app.MapControllers();

app.Run();