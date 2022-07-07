using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAndServices.DTOs.ServiceTypeDTOs
{
    /// <summary>
    /// Represents the service type model
    /// </summary>
    public class ServiceTypeReadDTO
    {
        /// <summary>
        /// Service type Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Service type description
        /// </summary>
        public string Description { get; set; }
    }
}
