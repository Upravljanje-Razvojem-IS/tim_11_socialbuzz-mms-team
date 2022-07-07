using ProductsAndServices.DTOs.ProductTypeDTOs;

namespace ProductsAndServices.DTOs.ProductDTOs
{
    /// <summary>
    /// Represents the product model
    /// </summary>
    public class ProductReadDTO
    {
        /// <summary>
        /// Product Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Product name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Product description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Product quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Product price
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Product type
        /// </summary>
        public ProductTypeReadDTO ProductType { get; set; }
    }
}
