using Api.Microservice.Libro.Modelo;
using AutoMapper;

namespace Api.Microservice.Libro.Aplicacion
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<LibreriaMaterial, LibroMaterialDto>();
        }
    }
}
