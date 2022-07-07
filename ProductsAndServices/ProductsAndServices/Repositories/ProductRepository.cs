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
        private readonly IProductTypeRepository productTypeRepository;

        //konstruktor sa parametrima klase ProductRepository
        public ProductRepository(DataContext context, IMapper mapper, IProductTypeRepository productTypeRepository)
        {
            this.context = context;
            this.mapper = mapper;
            this.productTypeRepository = productTypeRepository;
        }
        //ZAVRSENA METODA
        //metoda CreateProduct koja dodaje nov proizvod
        public ProductCreateDTO CreateProduct(ProductCreateDTO product)
        {
         

            var productEf = new Product();
            if (!CheckProductTypeExists(product.ProductTypeID))
            {
                throw new System.Exception("Foreign key violation!");
            }

            productEf.Name = product.Name;
            productEf.Description = product.Description;
            productEf.Price = product.Price;
            productEf.Quantity = product.Quantity;
            productEf.ProductTypeID = product.ProductTypeID;
            productEf.MockUserId = product.MockUserId;

            context.Products.Add(productEf);
            context.SaveChanges();

            return product;

        }

        //ZAVRSENA METODA
        //metoda koja vraca sve proizvode
        public List<ProductReadDTO> GetAll()
        {
            
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
                Quantity = p.Quantity,
                Price = p.Price,
                ProductType = productTypeRepository.GetById(p.ProductTypeID),
                MockForUser = MockUserData.MockUsers.FirstOrDefault(mc => mc.MockUserId == p.MockUserId)
            }).ToList();

            return productDTO;

        }

        //metoda koja update-uje postojeci proizvod po id-ju
        //ZAVRSENA METODA
        public ProductCreateDTO UpdateProduct(int id, ProductCreateDTO productDTO)
        {
            var product = context.Products.Find(id);
            if (product == null)
            {
                throw new Exception("Not found!");
            }
            if (!CheckProductTypeExists(product.ProductTypeID))
            {
                throw new System.Exception("Foreign key exception!");
            }

            product.Name = productDTO.Name;
            product.Description = productDTO.Description;
            product.Price = productDTO.Price;
            product.Quantity = productDTO.Quantity;
            product.ProductTypeID = productDTO.ProductTypeID;
            product.MockUserId = productDTO.MockUserId;

            context.Products.Update(product);
            context.SaveChanges();
            return productDTO;
        }

        //metoda DeleteProduct koja brise servis po id-ju
        //ZAVRSENA METODA
        public void DeleteProduct(int id)
        {
            var product = context.Products.FirstOrDefault(p => p.Id == id);
            //var product = context.Products.Find(id);
            if (product == null)
            {
                throw new Exception("Nije moguce obrisati!");
            }

            context.Products.Remove(product);
            context.SaveChanges();
        }

        //dodatne Get metode
        //metoda koja vraca proizvod po id-ju
        //ZAVRSENA METODA
        public ProductReadDTO GetById(int id)
        {
            var product = context.Products.Find(id);
          
            if(product == null)
            {
                throw new System.Exception("Product not found!");
            }

            var productDTO = new ProductReadDTO();
            productDTO.Id = product.Id;
            productDTO.Name = product.Name;
            productDTO.Description = product.Description;
            productDTO.Price = product.Price;
            productDTO.Quantity = product.Quantity;
            productDTO.ProductType = productTypeRepository.GetById(product.ProductTypeID);
            productDTO.MockForUser = MockUserData.MockUsers.FirstOrDefault(mc => mc.MockUserId == product.MockUserId);

            return productDTO;
        }

        //metoda koja vraca porizvod po imenu
        //ZAVRSENA METODA
        List<ProductReadDTO> IProductRepository.GetByName(string name)
        {
            var product = context.Products.Where(p => p.Name == name).ToList();

            if (product.Count() < 0)
            {
                throw new AppException("No products in database!");
            }

            var productDTO = product.Select(p => new ProductReadDTO
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Quantity = p.Quantity,
                Price = p.Price,
                ProductType = productTypeRepository.GetById(p.ProductTypeID),
                MockForUser = MockUserData.MockUsers.FirstOrDefault(mc => mc.MockUserId == p.MockUserId)
            }).ToList();

            
            return productDTO;
        }

        //metoda koja vraca proizvod po opisu
        //ZAVRSENA METODA
        List<ProductReadDTO> IProductRepository.GetByDescription(string description)
        {
            var product = context.Products.Where(p => p.Description == description).ToList();

            if (product.Count() < 0)
            {
                throw new AppException("No products in database!");
            }

            var productReadDTO = product.Select(p => new ProductReadDTO
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Quantity = p.Quantity,
                Price = p.Price,
                ProductType = productTypeRepository.GetById(p.ProductTypeID),
                MockForUser = MockUserData.MockUsers.FirstOrDefault(mc => mc.MockUserId == p.MockUserId)
            }).ToList();

            return productReadDTO;
        }

        

        //metoda koja vraca proizvod po kolicini proizvoda
        List<ProductReadDTO> IProductRepository.GetByQuantity(int quantity)
        {
            var product = context.Products.Where(p => p.Quantity == quantity).ToList();

            if (product.Count < 0)
            {
                throw new AppException("No services in database!");
            }

            var productReadDTO = product.Select(p => new ProductReadDTO
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Quantity = p.Quantity,
                Price = p.Price,
                ProductType = productTypeRepository.GetById(p.ProductTypeID),
                MockForUser = MockUserData.MockUsers.FirstOrDefault(mc => mc.MockUserId == p.MockUserId)
            }).ToList();

            return productReadDTO;
        }

        //metoda koja vraca listu proizvoda po ceni porizvoda
        List<ProductReadDTO> IProductRepository.GetByPrice(double price)
        {
            var product = context.Products.Where(p => p.Price == price).ToList();

            if (product.Count < 0)
            {
                throw new AppException("No services in database!");
            }

            var productReadDTO = product.Select(p => new ProductReadDTO
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Quantity = p.Quantity,
                Price = p.Price,
                ProductType = productTypeRepository.GetById(p.ProductTypeID),
                MockForUser = MockUserData.MockUsers.FirstOrDefault(mc => mc.MockUserId == p.MockUserId)
            }).ToList();

            return productReadDTO;
        }


        //metoda za validaciju ID-ja
        private bool CheckProductTypeExists(int id)
        {
            return context.ProductTypes.Any(pt => pt.ProductTypeID == id);
        }

    }
}
