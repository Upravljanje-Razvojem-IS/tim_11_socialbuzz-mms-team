﻿namespace ProductsAndServices.DTOs.ProductDTOs
{
    public class ProductReadDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public string ProductType { get; set; }
    }
}
