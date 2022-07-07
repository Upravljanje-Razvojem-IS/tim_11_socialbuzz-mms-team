using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAndServices.DTOs.ProductTypeDTOs
{
    /// <summary>
    /// Represents the product type model
    /// </summary>
    public class ProductTypeReadDTO
    {
        /// <summary>
        /// Product type Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Product type description
        /// </summary>
        public string Description { get; set; }
    }
}
