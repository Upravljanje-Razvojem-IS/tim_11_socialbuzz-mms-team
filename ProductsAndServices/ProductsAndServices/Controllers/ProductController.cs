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

        [HttpGet]
        public ActionResult GetAll()
        {
            var products = repository.GetAll();
            return Ok(products);
        }

        [HttpPost]
        public ActionResult PostProduct(ProductCreateDTO productDTO)
        {
            var product = repository.CreateProduct(productDTO);
            return Ok(product);
        }

        [HttpPut]
        public ActionResult PutProduct(int id, ProductCreateDTO productDTO)
        {
            var product = repository.UpdateProduct(id, productDTO);
            return Ok(product);
        }

        [HttpDelete]
        public ActionResult DeleteProduct(int id)
        {
            repository.DeleteProduct(id);
            return Ok(new { message = "Uspesno obrisan proizvod!" });
        }

        //dodatne Get metode
        [HttpGet]
        [Route("GetByID/{id}")]
        public ActionResult GetById(int id) {
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

        [HttpGet]
        [Route("GetByQuantity/{quantity}")]
        public ActionResult GetByQuantity(int quantity)
        {
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

        [HttpGet]
        [Route("GetByPrice/{price}")]
        public ActionResult GetByPrice(double price)
        {
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
