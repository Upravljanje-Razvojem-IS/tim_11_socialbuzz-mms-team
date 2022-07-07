namespace ProductsAndServices.DTOs.ProductDTOs
{
    /// <summary>
    /// Represents the product model
    /// </summary>
    public class ProductCreateDTO
    {
        /// <summary>
        /// Product dto name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Product dto description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Product dto quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Product dto price
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Product dto foreign key of product type
        /// </summary>
        public int ProductTypeID { get; set; }

        /// <summary>
        /// Product dto goreign key of mock user
        /// </summary>
        public int MockUserId { get; set; }
    }
}
