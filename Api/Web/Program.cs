using Core.Interfaces;
using Core.Interfaces.Repositorios;
using Core.Interfaces.Servicios;
using Core.Servicios;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Services.Services;
using System;
using System.IO;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Gracosoft .NET CORe",
        Description = "Aplicación de Bank DavNo",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Lino y David ",
            Url = new Uri("https://github.com/G3-Graco/laboratorio-proyecto-api-team-linus.git")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }

    });

    // Using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddControllers();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IArchivosRepository, ArchivosRepository>();
builder.Services.AddScoped<ICuentasRepository, CuentasRepository>();
builder.Services.AddScoped<ICuotasRepository, CuotasRepository>();
builder.Services.AddScoped<IMovimientosRepository, MovimientosRepository>();
builder.Services.AddScoped<IPrestamosRepository, PrestamosRepository>();
builder.Services.AddScoped<ISesionesRepository, SesionesRepository>();
builder.Services.AddScoped<ITasasRepository, TasasRepository>();
builder.Services.AddScoped<ITipoMovimientoRepository, TipoMovimientoRepository>();
builder.Services.AddScoped<IUsuariosRepository, UsuariosRepository>();
builder.Services.AddScoped<IArchivosPrestamosRepository, ArchivosPrestamosRepository>();



builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IArchivosService, ArchivoService>();
builder.Services.AddScoped<ICuentasService, CuentaService>();
builder.Services.AddScoped<ICuotasService, CuotaService>();
builder.Services.AddScoped<IMovimientosService, MovimientoService>();
builder.Services.AddScoped<IPrestamosService, PrestamoService>();
builder.Services.AddScoped<ISesionService, SesionService>();
builder.Services.AddScoped<ITasasService, TasaService>();
builder.Services.AddScoped<ITipoArchivosService, TipoArchivoService>();
builder.Services.AddScoped<ITipoMovimientoService, TipoMovimientoService>();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
app.UseHttpsRedirection();


app.MapControllers();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Gracosoft .NET CORe"));
}
app.UseHttpsRedirection();

app.Run();
