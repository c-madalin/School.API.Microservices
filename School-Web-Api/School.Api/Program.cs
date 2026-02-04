using Microsoft.EntityFrameworkCore;
using School.API.Database;
using School.API.Repository;
using School.API.Service;

var builder = WebApplication.CreateBuilder(args);

// 1. Configurare Baza de Date (Postgres)
builder.Services.AddDbContext<SchoolContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Dependency Injection (Legam interfetele de clase)
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();

// 3. Activam Controllerele
builder.Services.AddControllers();

// 4. CORS (Foarte important! Lasa Angular sa vorbeasca cu .NET)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        builder => builder.WithOrigins(
            "http://localhost:52904",   // Default Angular port
            "http://localhost:4201",   // Add other ports if needed
            "http://localhost:5115")   // Backend port for testing
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

var app = builder.Build();

// Configurare Pipeline
app.UseCors("AllowAngular");
app.UseAuthorization();
app.MapControllers();

app.Run();