using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsAndServices.DTOs.ServiceTypeDTOs;
using ProductsAndServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAndServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceTypeController : ControllerBase
    {
        private IServiceTypeRepository repository;

        /// <summary>
        /// Constructor with one param
        /// </summary>
        /// <param name="repository">ServiceTypeRepository param</param>
        public ServiceTypeController(IServiceTypeRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Get all service types
        /// </summary>
        /// <returns>List of service types</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet]
        public ActionResult GetAll()
        {
            var serviceType = repository.GetAllServiceTypes();
            if(serviceType == null)
            {
                return NotFound();
            }
            return Ok(serviceType);
        }

        /// <summary>
        /// Create a new service type
        /// </summary>
        /// <param name="serviceType">Name of service</param>
        /// <returns>Created service type</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public ActionResult CreateServiceType(ServiceTypeCreateDTO serviceType)
        {
            if(serviceType == null)
            {
                return BadRequest();
            }
            repository.CreateServiceType(serviceType);
            return Ok(new { message = "Service type is created!" });
        }

        /// <summary>
        /// Update a service type
        /// </summary>
        /// <param name="id">Id of service type</param>
        /// <param name="serviceTypeCreateDTO">Name of service type</param>
        /// <returns>Updated service type</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut]
        public ActionResult UpdateServiceType(int id, ServiceTypeCreateDTO serviceTypeCreateDTO)
        {
            if (id < 0 || serviceTypeCreateDTO == null)
            {
                return BadRequest();
            }

            var serviceType = repository.GetById(id);
            if(serviceType == null)
            {
                return NotFound();
            }

            repository.UpdateServiceType(id, serviceTypeCreateDTO);
            return Ok(new { message = "Service type is updated!" });
        }

        /// <summary>
        /// Delete a service type
        /// </summary>
        /// <param name="id">Id of service type</param>
        /// <returns>Deleted service type</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpDelete]
        public ActionResult DeleteServiceType(int id)
        {
            if(id < 0)
            {
                return BadRequest();
            }
            var serviceType = repository.GetById(id);
            if(serviceType == null)
            {
                return NotFound();
            }
            repository.DeleteServiceType(id);
            return Ok(new { message = "Service type deleted!" });
        }

        /// <summary>
        /// Get single service type based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet]
        [Route("GetByServiceTypeID/{id}")]
        public ActionResult GetById(int id)
        {
            var serviceType = repository.GetById(id);
            if(serviceType == null)
            {
                return NotFound();
            }

            return Ok(serviceType);
        }

        /// <summary>
        /// Get service type with this description
        /// </summary>
        /// <param name="description">Description of service type</param>
        /// <returns>Single description of service type or return a list of these service types with this description</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet]
        [Route("GetByDescription/{description}")]
        public ActionResult GetByDescription(string description)
        {
            var serviceType = repository.GetByDescription(description);
            if(serviceType == null)
            {
                return NotFound();
            }
            return Ok(serviceType);
        }
    }
}
