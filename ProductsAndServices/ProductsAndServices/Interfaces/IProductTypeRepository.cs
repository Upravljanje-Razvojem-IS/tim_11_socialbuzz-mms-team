using ProductsAndServices.DTOs.ProductTypeDTOs;
using System.Collections.Generic;

namespace ProductsAndServices.Interfaces
{
    public interface IProductTypeRepository
    {
        List<ProductTypeReadDTO> GetAllProductTypes();
        ProductTypeCreateDTO CreateProductType(ProductTypeCreateDTO productTypeCreateDTO);
        ProductTypeCreateDTO UpdateProductType(int id, ProductTypeCreateDTO productTypeCreateDTO);

        void DeleteProductType(int id);
        ProductTypeReadDTO GetById(int id);

        List<ProductTypeReadDTO> GetByDescription(string description);
    }
}
