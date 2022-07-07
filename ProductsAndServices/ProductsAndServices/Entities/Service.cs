using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsAndServices.Entities
{
    /// <summary>
    /// Service model
    /// </summary>
    public class Service
    {
        /// <summary>
        /// Service Id
        /// </summary>
        [Key]
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Service name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Service description
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Service price
        /// </summary>
        [Required]
        public double Price { get; set; }

        /// <summary>
        /// Foreign key of service type
        /// </summary>
        [ForeignKey("ServiceTypeID")]
        public int ServiceTypeID { get; set; }

        /// <summary>
        /// Service type
        /// </summary>
        public virtual ServiceType ServiceType { get; set; }
    }
}
