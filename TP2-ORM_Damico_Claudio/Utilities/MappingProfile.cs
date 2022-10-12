using AutoMapper;
using TP1_ORM_Domain.Dtos;
using TP1_ORM_Domain.Entities;

namespace TP2_ORM_Damico_Claudio.Utilities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<Producto, ProductoDto>().ReverseMap();  
            CreateMap<Carrito, CarritoDto>().ReverseMap();
        }
    }
}
