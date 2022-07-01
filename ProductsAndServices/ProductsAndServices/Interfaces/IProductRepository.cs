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
        ProductReadDTO GetByName(string name);
        ProductReadDTO GetByDescription(string description);
        ProductReadDTO GetByQuantity(int quantity);
        ProductReadDTO GetByPrice(double price);

    }
}
