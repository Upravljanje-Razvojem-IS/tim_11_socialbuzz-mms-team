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

    }
}
