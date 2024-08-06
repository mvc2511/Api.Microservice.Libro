using Api.Microservice.Libro.Modelo;
using Api.Microservice.Libro.Persistencia;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Api.Microservice.Libro.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public string Titulo { get; set; }
            public DateTime? FechaPublicacion { get; set; }
            public Guid? AutorLibro { get; set; }
            public double Precio { get; set; }
            public IFormFile Imagen { get; set; }
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(p => p.Titulo).NotEmpty();
                RuleFor(p => p.FechaPublicacion).NotEmpty();
                RuleFor(p => p.AutorLibro).NotEmpty();
                RuleFor(p => p.Precio).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly ContextoLibreria _context;

            public Manejador(ContextoLibreria contexto)
            {
                _context = contexto;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                try
                {
                    byte[] imagenBytes = null;
                    if (request.Imagen != null)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await request.Imagen.CopyToAsync(memoryStream);
                            imagenBytes = memoryStream.ToArray();
                        }
                    }

                    var libro = new LibreriaMaterial
                    {
                        Titulo = request.Titulo,
                        FechaPublicacion = request.FechaPublicacion?.ToUniversalTime(),
                        AutorLibro = request.AutorLibro,
                        Precio = request.Precio,
                        Imagen = imagenBytes // Asigna la imagen convertida
                    };

                    _context.LibreriasMaterial.Add(libro);
                    var valor = await _context.SaveChangesAsync();

                    if (valor > 0)
                    {
                        return Unit.Value;
                    }
                    else
                    {
                        throw new Exception("No se pudo guardar el libro en la base de datos.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al intentar guardar el libro:");
                    Console.WriteLine(ex.Message);

                    if (ex.InnerException != null)
                    {
                        Console.WriteLine("Inner Exception:");
                        Console.WriteLine(ex.InnerException.Message);
                    }

                    throw;
                }
            }
        }
    }
}