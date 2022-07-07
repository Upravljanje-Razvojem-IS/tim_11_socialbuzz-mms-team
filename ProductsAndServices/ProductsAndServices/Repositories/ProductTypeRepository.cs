using AutoMapper;
using ProductsAndServices.DTOs.ProductTypeDTOs;
using ProductsAndServices.Entities;
using ProductsAndServices.Exceptions;
using ProductsAndServices.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ProductsAndServices.Repositories
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        //konstruktor sa parametrima klase ProductTypeRepository
        public ProductTypeRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public ProductTypeCreateDTO CreateProductType(ProductTypeCreateDTO productTypeCreateDTO)
        {
            var productTypeEf = new ProductType();
            productTypeEf.Description = productTypeCreateDTO.Description;
            context.Add(productTypeEf);
            context.SaveChanges();
            return productTypeCreateDTO;
        }

        public ProductTypeCreateDTO UpdateProductType(int id, ProductTypeCreateDTO productTypeCreateDTO)
        {
            var productTypeEf = context.ProductTypes.Find(id);
            if (productTypeEf == null)
            {
                throw new Exceptions.KeyNotFoundException("Product type not found!");
            }

            productTypeEf.Description = productTypeCreateDTO.Description;
            context.ProductTypes.Update(productTypeEf);
            context.SaveChanges();

            return productTypeCreateDTO;
        }

        public void DeleteProductType(int id)
        {
            var productType = context.ProductTypes.Find(id);
            if(productType == null)
            {
                //throw new AppException("Product type doesn't exist!");
                throw new Exceptions.KeyNotFoundException();
            }
            context.ProductTypes.Remove(productType);
            context.SaveChanges();
        }


        public List<ProductTypeReadDTO> GetAllProductTypes()
        {
            var productType = context.ProductTypes.ToList();
            if (productType.Count() < 0)
            {
                throw new AppException("No products in database!");
            }
            var productTypeDTO = productType.Select(p => new ProductTypeReadDTO
            {
                Id = p.ProductTypeID,
                Description = p.Description,
                // ProductType = context.ProductTypes.Find(p.ProductTypeID).Description
            }).ToList();

            return productTypeDTO;
        }

        //dodatne Get metode

        public ProductTypeReadDTO GetById(int id)
        {
            var productType = context.ProductTypes.Find(id);
            if(productType == null)
            {
                throw new Exceptions.KeyNotFoundException("Product type is not found!");
            }
            var productTypeReadDTO = new ProductTypeReadDTO();
            productTypeReadDTO.Id = id;
            productTypeReadDTO.Description = productType.Description;
            //productTypeReadDTO.Description = context.ProductTypes.Find(productType.ProductTypeID).Description;

            return productTypeReadDTO;
        }

        public List<ProductTypeReadDTO> GetByDescription(string description)
        {
            var productType = context.ProductTypes.Where(pt => pt.Description == description).ToList();
            if (productType == null)
            {
                throw new Exceptions.AppException("No product type in database!");
            }

            var productTypeReadDTO = productType.Select(pt => new ProductTypeReadDTO
            {
                Id = pt.ProductTypeID,
                Description = pt.Description,
            }).ToList();


            return productTypeReadDTO;
        }

        
    }
}
