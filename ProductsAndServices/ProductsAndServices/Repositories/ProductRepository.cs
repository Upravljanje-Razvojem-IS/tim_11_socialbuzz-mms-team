using AutoMapper;
using ProductsAndServices.DTOs.ProductDTOs;
using ProductsAndServices.Entities;
using ProductsAndServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAndServices.Repositories
{
    public class ProductRepository : IProductRepository
    {
        //deklaracija parametara koji se prosledjuju konstruktoru
        private readonly DataContext context;
        private readonly IMapper mapper;

        //konstruktor sa parametrima klase ProductRepository
        public ProductRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        //metoda CreateProduct koja dodaje nov proizvod
        public ProductCreateDTO CreateProduct(ProductCreateDTO product)
        {
            var productEf = mapper.Map<Product>(product);
            context.Products.Add(productEf);
            context.SaveChanges();
            return product;

        }

        //metoda DeleteProduct koja brise servis po id-ju
        public void DeleteProduct(int id)
        {
            var product = context.Products.FirstOrDefault(p => p.Id == id);
            if(product == null)
            {
                throw new Exception("Nije moguce obrisati!");
            }

            context.Products.Remove(product);
            context.SaveChanges();
        }

        public List<ProductReadDTO> GetAll()
        {
            var product = context.Products.ToList();
            return mapper.Map<List<ProductReadDTO>>(product);
            
        }

        public ProductReadDTO GetById(int id)
        {
            var product = context.Products.Find(id);
            return mapper.Map<ProductReadDTO>(product);
        }

        public ProductCreateDTO UpdateProduct(int id, ProductCreateDTO productDTO)
        {
            var product = context.Products.Find(id);
            if(product == null )
            {
                throw new Exception("Nije pronadjen trazeni proizvod!");
            }

            product.Name = productDTO.Name;
            product.Description = productDTO.Description;
            product.Price = productDTO.Price;
            product.Quantity = productDTO.Quantity;

            context.SaveChanges();
            return productDTO;
        }
    }
}
