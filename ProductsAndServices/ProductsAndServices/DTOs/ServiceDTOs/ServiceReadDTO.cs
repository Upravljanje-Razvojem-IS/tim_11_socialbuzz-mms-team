using ProductsAndServices.DTOs.ServiceTypeDTOs;

namespace ProductsAndServices.DTOs.ServiceDTOs
{
    /// <summary>
    /// Represents the service model
    /// </summary>
    public class ServiceReadDTO
    {
        /// <summary>
        /// Service Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Service name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Service description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Service price
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Service type
        /// </summary>
        public ServiceTypeReadDTO ServiceType { get; set; }
    }
}
