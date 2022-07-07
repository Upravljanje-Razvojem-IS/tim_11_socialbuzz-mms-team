using Microsoft.AspNetCore.Http;
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

        /// <summary>
        /// Get all services
        /// </summary>
        /// <returns>List of services</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet]
        public ActionResult GetAll()
        {
            var services = repository.GetAll();
            if(services.Count < 0)
            {
                return NotFound();
            }
            return Ok(services);
        }

        /// <summary>
        /// Create a new service
        /// </summary>
        /// <param name="serviceDTO">Name of service</param>
        /// <returns>Created service</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public ActionResult PostService(ServiceCreateDTO serviceDTO)
        {
            var service = repository.CreateService(serviceDTO);
            return Ok(service);
        }

        /// <summary>
        /// Update a service
        /// </summary>
        /// <param name="id">Id of service</param>
        /// <param name="serviceDTO">Name of service</param>
        /// <returns>Updated service</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut]
        public ActionResult PutService(int id, ServiceCreateDTO serviceDTO)
        {
            if (id < 0 || serviceDTO == null)
            {
                return BadRequest();
            }
            var service = repository.UpdateService(id, serviceDTO);
            return Ok(service);
            //return CreatedAtAction(nameof(service),new { message = "Service is updated" });
        }

        /// <summary>
        /// Delete a service
        /// </summary>
        /// <param name="id">Id of service</param>
        /// <returns>Deleted service</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpDelete]
        public ActionResult DeleteService(int id)
        {
            repository.DeleteService(id);
            return Ok(new { message = "Uspesno obrisan servis!" });
        }

        //dodatne Get metode
        /// <summary>
        /// Get single service based on id
        /// </summary>
        /// <param name="id">Id of service</param>
        /// <returns>List of services or single product</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet]
        [Route("GetById/{id}")]
        public ActionResult GetById(int id)
        {
            if(id < 0)
            {
                return BadRequest();
            }
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

        /// <summary>
        /// Get service with this name
        /// </summary>
        /// <param name="name">Name of service</param>
        /// <returns>Single name of service or return a list of these services with this name</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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

        /// <summary>
        /// Get service with this description
        /// </summary>
        /// <param name="description">Description of service</param>
        /// <returns>Single description of service or return a list of these services with this description</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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

        /// <summary>
        /// Get service with this price
        /// </summary>
        /// <param name="price">Price of service</param>
        /// <returns>Single service or multiple products with this price</returns>
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
