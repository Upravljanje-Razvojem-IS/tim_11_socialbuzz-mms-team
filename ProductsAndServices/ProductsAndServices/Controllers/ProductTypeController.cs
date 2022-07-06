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

        public ProductTypeController(IProductTypeRepository repository)
        {
            this.repository = repository;
        }

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
