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
    }
}
