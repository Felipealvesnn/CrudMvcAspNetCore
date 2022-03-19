using AutoMapper;
using MacorattiMVC.Domain.Entitites;
using MacorratiMVC.Application.DTOs;

namespace MacorratiMVC.Application.Maps
{
    public class DomainTOMappingProfile : Profile
    {
        public DomainTOMappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
        }

    }
}
