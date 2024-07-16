using Api.Microservice.Libro.Aplicacion;
using Api.Microservice.Libro.Persistencia;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Api.Microservice.Libro.Extensiones
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers()
                .AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<Nuevo>());


            //Reemplazar por PostGre
            //services.AddDbContext<ContextoLibreria>(options =>
            //options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
            //new MySqlServerVersion(new Version(8, 0, 23))));
            services.AddDbContext<ContextoLibreria>(options =>
             options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            //Agregar servicios Cors
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder =>
                    {
                        builder.WithOrigins("https://example.com", "https://another-example.com", "http://localhost:3000")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                    });
            });

            //agregamos MediatR como servicio
            services.AddMediatR(typeof(Nuevo.Manejador).Assembly);
            services.AddAutoMapper(typeof(Consulta.Manejador));

            return services;
        }
    }
}
