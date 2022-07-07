using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsAndServices.Entities
{
    /// <summary>
    /// Product model
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Product Id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Product name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Product description
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Product quantity
        /// </summary>
        [Required]
        public int Quantity { get; set; }

        /// <summary>
        /// Product price
        /// </summary>
        [Required]
        public double Price { get; set; }

        /// <summary>
        /// Foreign key of product type
        /// </summary>
        [ForeignKey("ProductTypeID")]
        public int ProductTypeID { get; set; }

        /// <summary>
        /// Product type
        /// </summary>
        public virtual ProductType ProductType { get; set; }

    }
}
