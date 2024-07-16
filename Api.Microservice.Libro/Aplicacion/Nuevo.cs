using Api.Microservice.Libro.Modelo;
using Api.Microservice.Libro.Persistencia;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Api.Microservice.Libro.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public string Titulo { get; set; }

            public double Precio { get; set; }

            public DateTime? FechaPublicacion { get; set; }

            public Guid AutorLibro { get; set; }
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {

            public EjecutaValidacion()
            {
                RuleFor(x => x.Titulo).NotEmpty();
                RuleFor(x => x.Precio).NotEmpty();
                RuleFor(x => x.FechaPublicacion).NotEmpty();
                RuleFor(x => x.AutorLibro).NotEmpty();
            }
        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly ContextoLibreria _contexto;
            //private readonly ILogger<Manejador> _logger;

            public Manejador(ContextoLibreria contexto, ILogger<Manejador> logger)
            {
                _contexto = contexto;
                //_logger = logger;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var libro = new LibreriaMaterial
                {
                    Titulo = request.Titulo,
                    Precio = request.Precio,
                    FechaPublicacion = request.FechaPublicacion,
                    AutorLibro = request.AutorLibro
                };
                _contexto.LibreriasMaterial.Add(libro);
                var valor = await _contexto.SaveChangesAsync();
                // Log the result of SaveChangesAsync
                //_logger.LogInformation("SaveChangesAsync result: {Valor}", valor);
                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo guardar el libro");
            }
        }
    }
}