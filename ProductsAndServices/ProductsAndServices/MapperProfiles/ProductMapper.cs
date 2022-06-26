using AutoMapper;
using ProductsAndServices.DTOs.ProductDTOs;
using ProductsAndServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAndServices.MapperProfiles
{
    public class ProductMapper : Profile
    {
        public ProductMapper() {
            CreateMap<Product, ProductReadDTO>();

            CreateMap<ProductCreateDTO, Product>();
        }

    }
}
