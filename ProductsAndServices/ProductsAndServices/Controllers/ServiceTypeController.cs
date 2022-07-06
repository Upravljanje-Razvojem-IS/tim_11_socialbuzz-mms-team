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

        public ServiceTypeController(IServiceTypeRepository repository)
        {
            this.repository = repository;
        }

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
