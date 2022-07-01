using Microsoft.AspNetCore.Mvc;
using ProductsAndServices.DTOs.ServiceDTOs;
using ProductsAndServices.Interfaces;

namespace ProductsAndServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepository repository;

        public ServiceController(IServiceRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var services = repository.GetAll();
            return Ok(services);
        }

        [HttpPost]
        public ActionResult PostService(ServiceCreateDTO serviceDTO)
        {
            var service = repository.CreateService(serviceDTO);
            return Ok(service);
        }

        [HttpPut]
        public ActionResult PutService(int id, ServiceCreateDTO serviceDTO)
        {
            var service = repository.UpdateService(id, serviceDTO);
            return Ok(service);
        }

        [HttpDelete]
        public ActionResult DeleteService(int id)
        {
            repository.DeleteService(id);
            return Ok(new { message = "Uspesno obrisan servis!" });
        }

        //dodatne Get metode
        [HttpGet]
        [Route("GetById/{id}")]
        public ActionResult GetById(int id)
        {
            var service = repository.GetById(id);
            if(service == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(service);
            }
        }

        [HttpGet]
        [Route("GetByName/{name}")]
        public ActionResult GetByName(string name)
        {
            var service = repository.GetByName(name);
            if(service == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(service);
            }
        }

        [HttpGet]
        [Route("GetByDescription/{description}")]
        public ActionResult GetByDescription(string description)
        {
            var service = repository.GetByDescription(description);
            if(service == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(service);
            }
        }

        [HttpGet]
        [Route("GetByPrice/{price}")]
        public ActionResult GetByPrice(double price)
        {
            var service = repository.GetByPrice(price);
            if(service == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(service);
            }
        }

    }
}
