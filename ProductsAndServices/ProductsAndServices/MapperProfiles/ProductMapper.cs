using AutoMapper;
using ProductsAndServices.DTOs.ProductDTOs;
using ProductsAndServices.Entities;

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
