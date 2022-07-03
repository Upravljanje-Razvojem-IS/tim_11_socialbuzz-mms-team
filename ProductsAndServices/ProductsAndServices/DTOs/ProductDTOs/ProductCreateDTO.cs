namespace ProductsAndServices.DTOs.ProductDTOs
{
    public class ProductCreateDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public int ProductTypeID { get; set; }
    }
}
