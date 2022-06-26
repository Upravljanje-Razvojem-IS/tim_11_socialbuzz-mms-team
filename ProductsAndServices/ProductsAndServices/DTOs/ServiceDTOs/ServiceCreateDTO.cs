using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAndServices.DTOs.ServiceDTOs
{
    public class ServiceCreateDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }
    }
}
