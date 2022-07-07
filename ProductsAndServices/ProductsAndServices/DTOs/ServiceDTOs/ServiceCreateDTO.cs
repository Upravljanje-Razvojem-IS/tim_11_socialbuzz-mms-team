namespace ProductsAndServices.DTOs.ServiceDTOs
{
    /// <summary>
    /// Represents the service model
    /// </summary>
    public class ServiceCreateDTO
    {
        /// <summary>
        /// Service dto name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Service dto description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Service dto price
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Service dto foreign key service type
        /// </summary>
        public int ServiceTypeID { get; set; }

        /// <summary>
        /// Product dto goreign key of mock user
        /// </summary>
        public int MockUserId { get; set; }
    }
}
