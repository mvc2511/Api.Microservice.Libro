using Api.Microservice.Libro.Modelo;
using Api.Microservice.Libro.Persistencia;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Microservice.Libro.Aplicacion
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<LibroMaterialDto>>
        {
            public Ejecuta()
            {


            }
        }

        public class Manejador : IRequestHandler<Ejecuta, List<LibroMaterialDto>>
        {
            private readonly IMapper _mapper;
            private readonly ContextoLibreria _contexto;

            public Manejador(ContextoLibreria contexto, IMapper mapper)
            {
                _mapper = mapper;
                _contexto = contexto;
            }

            public async Task<List<LibroMaterialDto>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var libros = await _contexto.LibreriasMaterial.ToListAsync();
                var librosDto = _mapper.Map<List<LibreriaMaterial>, List<LibroMaterialDto>>(libros);
                return librosDto;
            }

        }




    }
}
