using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsAndServices.DTOs.ProductDTOs;
using ProductsAndServices.Interfaces;

namespace ProductsAndServices.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository repository;

        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>List of products</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet]
        public ActionResult GetAll()
        {
            var products = repository.GetAll();
            if (products.Count < 0)
            {
                return NotFound();
            }
            return Ok(products);
        }

        /// <summary>
        /// Create a new product
        /// </summary>
        /// <param name="productDTO">Name of product</param>
        /// <returns>Created product</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public ActionResult PostProduct(ProductCreateDTO productDTO)
        {
            var product = repository.CreateProduct(productDTO);
            return Ok(product);
        }

        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="id">Id of product</param>
        /// <param name="productDTO">Name of product</param>
        /// <returns>Updated product</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut]
        public ActionResult PutProduct(int id, ProductCreateDTO productDTO)
        {
            var product = repository.UpdateProduct(id, productDTO);
            return Ok(product);
        }

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="id">Id of product</param>
        /// <returns>Deleted product</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpDelete]
        public ActionResult DeleteProduct(int id)
        {
            repository.DeleteProduct(id);
            return Ok(new { message = "Uspesno obrisan proizvod!" });
        }

        //dodatne Get metode
        /// <summary>
        /// Get single product based on id
        /// </summary>
        /// <param name="id">Id of product</param>
        /// <returns>List of products or single product</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet]
        [Route("GetByID/{id}")]
        public ActionResult GetById(int id) {
            if (id < 0)
            {
                return BadRequest();
            }
            var product = repository.GetById(id);
            if(product == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }

        /// <summary>
        /// Get product with this name
        /// </summary>
        /// <param name="name">Name of product</param>
        /// <returns>Single name of product or return a list of these products with this name</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet]
        [Route("GetByName/{name}")]
        public ActionResult GetByName(string name)
        {
            var product = repository.GetByName(name);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }

        }

        /// <summary>
        /// Get product with this description
        /// </summary>
        /// <param name="description">Description of product</param>
        /// <returns>Single description of product or return a list of these products with this description</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet]
        [Route("GetByDescription/{description}")]
        public ActionResult GetByDescription(string description)
        {
            var product = repository.GetByDescription(description);
            if(product == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }

        /// <summary>
        /// Get product with this quantity
        /// </summary>
        /// <param name="quantity">Quantity of product</param>
        /// <returns>Quantity of products or return a list of these products with this quantity</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet]
        [Route("GetByQuantity/{quantity}")]
        public ActionResult GetByQuantity(int quantity)
        {
            if(quantity < 0)
            {
                return BadRequest();
            }
            var product = repository.GetByQuantity(quantity);
            if(product == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }

        /// <summary>
        /// Get product with this price   
        /// </summary>
        /// <param name="price">Price of product</param>
        /// <returns>Single or multiple products with this price</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet]
        [Route("GetByPrice/{price}")]
        public ActionResult GetByPrice(double price)
        {
            if(price < 0)
            {
                return BadRequest();
            }
            var product = repository.GetByPrice(price);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }
    }
}
