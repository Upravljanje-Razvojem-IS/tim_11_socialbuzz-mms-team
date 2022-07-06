using AutoMapper;
using ProductsAndServices.DTOs.ProductDTOs;
using ProductsAndServices.Entities;
using ProductsAndServices.Exceptions;
using ProductsAndServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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

        //metoda koja vraca sve proizvode
        public List<ProductReadDTO> GetAll()
        {
            //var product = context.Products.ToList();
            //return mapper.Map<List<ProductReadDTO>>(product);

            var product = context.Products.ToList();
            if(product.Count() < 0)
            {
                throw new AppException("No products in database!");
            }
            var productDTO = product.Select(p => new ProductReadDTO
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Quantity = p.Quantity,
                ProductType = context.ProductTypes.Find(p.ProductTypeID).Description
            }).ToList();

            return productDTO;

        }

        //metoda koja update-uje postojeci proizvod po id-ju
        public ProductCreateDTO UpdateProduct(int id, ProductCreateDTO productDTO)
        {
            var product = context.Products.Find(id);
            if (product == null)
            {
                throw new Exception("Nije pronadjen trazeni proizvod!");
            }

            product.Name = productDTO.Name;
            product.Description = productDTO.Description;
            product.Price = productDTO.Price;
            product.Quantity = productDTO.Quantity;
            product.ProductTypeID = 1;

            context.Products.Update(product);
            context.SaveChanges();
            return productDTO;
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

        //dodatne Get metode
        //metoda koja vraca proizvod po id-ju
        public ProductReadDTO GetById(int id)
        {
            var product = context.Products.Find(id);
            return mapper.Map<ProductReadDTO>(product);
        }

        //metoda koja vraca porizvod po imenu
        public ProductReadDTO GetByName(string name)
        {
            var product = context.Products.FirstOrDefault(p => p.Name == name);
            if(product == null)
            {
                throw new Exception("Product is not found!");
            }

            var productReadDTO = new ProductReadDTO 
            { 
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Quantity = product.Quantity,
                Price = product.Price
            };

            return productReadDTO;
        }

        //metoda koja vraca proizvod po opisu
        public ProductReadDTO GetByDescription( string description)
        {
            var product = context.Products.FirstOrDefault(p => p.Description == description);

            if(product == null)
            {
                throw new Exception("Product is not found!");
            }

            var productReadDTO = new ProductReadDTO 
            { 
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Quantity = product.Quantity,
                Price = product.Price
            };

            return productReadDTO;
        }

        //metoda koja vraca proizvod po kolicini proizvoda
        public ProductReadDTO GetByQuantity (int quantity)
        {
            var product = context.Products.FirstOrDefault(p => p.Quantity == quantity);

            if (product == null)
            {
                throw new Exception("Product is not found!");
            }

            var productReadDTO = new ProductReadDTO 
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Quantity = product.Quantity,
                Price = product.Price
            };
            
            return productReadDTO;
        }

        //metoda koja vraca proizvod po ceni porizvoda
        public ProductReadDTO GetByPrice(double price)
        {
            var product = context.Products.FirstOrDefault(p => p.Price == price);

            if (product == null)
            {
                throw new Exception("Product is not found!");
            }

            var productReadDTO = new ProductReadDTO 
            { 
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Quantity = product.Quantity,
                Price = product.Price
            };

            return productReadDTO;
        
        }
    }
}
