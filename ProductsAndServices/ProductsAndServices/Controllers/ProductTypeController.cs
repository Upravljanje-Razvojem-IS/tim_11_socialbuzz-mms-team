using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsAndServices.DTOs.ProductTypeDTOs;
using ProductsAndServices.Interfaces;

namespace ProductsAndServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private IProductTypeRepository repository;

        /// <summary>
        /// Constructor with one param
        /// </summary>
        /// <param name="repository">ProductTypeRepository param</param>
        public ProductTypeController(IProductTypeRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Get all product types
        /// </summary>
        /// <returns>List of product types</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet]
        public ActionResult GetAll()
        {
            var productType = repository.GetAllProductTypes();
            if(productType == null)
            {
                return NotFound();
            }
            return Ok(productType);
        }

        /// <summary>
        /// Create a new product type
        /// </summary>
        /// <param name="productType">Name of product</param>
        /// <returns>Created product type</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public ActionResult CreateProductType (ProductTypeCreateDTO productType)
        {
            if(productType == null)
            {
                return BadRequest();
            }
            repository.CreateProductType(productType);
            return Ok(new { message = "Product type is created!" });
        }

        /// <summary>
        /// Update a product type
        /// </summary>
        /// <param name="id">Id of product type</param>
        /// <param name="productTypeCreateDTO">Name of product type</param>
        /// <returns>Updated product type</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut]
        public ActionResult UpdateProductType(int id, ProductTypeCreateDTO productTypeCreateDTO)
        {
            if(id < 0 || productTypeCreateDTO == null)
            {
                return BadRequest();
            }

            var productTypeEf = repository.GetById(id);
            if(productTypeEf == null)
            {
                return NotFound();
            }

            repository.UpdateProductType(id, productTypeCreateDTO);
            return Ok(new { message = "Product type is updated!" });
        }

        /// <summary>
        /// Delete a product type
        /// </summary>
        /// <param name="id">Id of product type</param>
        /// <returns>Deleted product type</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpDelete]
        public ActionResult DeleteProductType(int id)
        {
            if(id < 0)
            {
                return BadRequest();
            }
            var productType = repository.GetById(id);
            if(productType == null)
            {
                return NotFound();
            }
            repository.DeleteProductType(id);
            return Ok(new { message = "Product type deleted!" });
        }

        /// <summary>
        /// Get single product type based on id
        /// </summary>
        /// <param name="id">Id of product type</param>
        /// <returns>Single product type</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet]
        [Route("GetByProductTypeID/{id}")]
        public ActionResult GetById(int id)
        {
            var productType = repository.GetById(id);
            if(productType == null)
            {
                return NotFound();
            }
            return Ok(productType);
        }

        /// <summary>
        /// Get product type with this description
        /// </summary>
        /// <param name="description">Description of product type</param>
        /// <returns>Single description of product type or return a list of these product types with this description</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet]
        [Route("GetByDescription/{description}")]
        public ActionResult GetByDescription(string description)
        {
            var productType = repository.GetByDescription(description);
            if(productType == null)
            {
                return NotFound();
            }
            return Ok(productType);
        }
    }
}
