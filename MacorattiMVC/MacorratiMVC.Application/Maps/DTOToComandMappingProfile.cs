using AutoMapper;
using MacorratiMVC.Application.DTOs;
using MacorratiMVC.Application.Products.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacorratiMVC.Application.Maps
{
    public class DTOToComandMappingProfile : Profile
    {
        public DTOToComandMappingProfile()
        {
            CreateMap<ProductDTO, ProductCreateCommand>();
            CreateMap<ProductDTO, ProductUpdateCommand>();
        }
    }
}
