using ProductsAndServices.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAndServices.Interfaces
{
    public interface IProductRepository
    {
        List<ProductReadDTO> GetAll();

        ProductReadDTO GetById(int id);

        ProductCreateDTO CreateProduct(ProductCreateDTO product);
        ProductCreateDTO UpdateProduct(int id, ProductCreateDTO product);

        void DeleteProduct(int id);

        //dodatne metode
    }
}
