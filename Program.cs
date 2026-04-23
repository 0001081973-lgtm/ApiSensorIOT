using APIIoT.Repositories;
using ApiSensoresIOT.Data;
using ApiSensoresIOT.Repositories;
using ApiSensoresIOT.Repositories.Interfaces;
using ApiSensoresIOT.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Swagger + documentação
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    options.IncludeXmlComments(xmlPath);
});

// 🔹 Banco de dados SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=sensores.db"));

// 🔹 Injeção de dependência
builder.Services.AddScoped<ISensorRepository, SensorRepository>();
builder.Services.AddScoped<SensorService>();

// 🔹 Controllers
builder.Services.AddControllers();

var app = builder.Build();

// 🔹 Swagger sempre ativo (igual exemplo do professor)
app.UseSwagger();
app.UseSwaggerUI();

// 🔹 Middlewares
app.UseHttpsRedirection();

app.MapControllers();

app.Run();