using ProductsAndServices.DTOs.ProductDTOs;
using System.Collections.Generic;

namespace ProductsAndServices.Interfaces
{
    public interface IProductRepository
    {
        List<ProductReadDTO> GetAll();
        ProductCreateDTO CreateProduct(ProductCreateDTO product);
        ProductCreateDTO UpdateProduct(int id, ProductCreateDTO product);

        void DeleteProduct(int id);

        //dodatne metode
        ProductReadDTO GetById(int id);
        List<ProductReadDTO> GetByName(string name);
        List<ProductReadDTO> GetByDescription(string description);
        List<ProductReadDTO> GetByQuantity(int quantity);
        List<ProductReadDTO> GetByPrice(double price);

    }
}
