using Api.Microservice.Libro.Modelo;
using AutoMapper;

namespace Api.Microservice.Libro.Aplicacion
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {

            CreateMap<LibreriaMaterial, LibroMaterialDto>()
                .ForMember(dest => dest.Imagenes, opt => opt.MapFrom(src => src.Imagen))
                .ForMember(dest => dest.Imagen, opt => opt.Ignore()); // Ignora esta propiedad ya que no puede mapearse directamente

            CreateMap<LibroMaterialDto, LibreriaMaterial>()
                .ForMember(dest => dest.Imagen, opt => opt.MapFrom(src => src.Imagenes));
        }
    }
}
