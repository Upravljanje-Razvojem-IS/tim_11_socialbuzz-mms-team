using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAndServices.Entities
{
    /// <summary>
    /// Product Type model
    /// </summary>
    public class ProductType
    {
        /// <summary>
        /// Product type id
        /// </summary>
        public int ProductTypeID { get; set; }

        /// <summary>
        /// Product type description
        /// </summary>
        public string Description { get; set; }
    }
}
