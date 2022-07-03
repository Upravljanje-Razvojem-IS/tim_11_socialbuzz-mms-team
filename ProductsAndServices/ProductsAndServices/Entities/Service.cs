using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsAndServices.Entities
{
    public class Service
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        [ForeignKey("ServiceTypeID")]
        public int ServiceTypeID { get; set; }

        public virtual ServiceType ServiceType { get; set; }
    }
}
