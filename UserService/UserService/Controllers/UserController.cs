using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UserService.Entities;
using UserService.Repositories;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository repository;

        public UserController(IUserRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var user = repository.GetAll();
            return Ok(user);
        }

        /*[HttpGet("{id:int}")]
        public ActionResult GetById(int id)
        {
            var entity = repository.GetById(id);
            return Ok(entity);
        }

        [HttpGet("{username:alpha}")]
        public ActionResult GetByUsername(string username)
        {
            var enitity = repository.GetByUsername(username);
            return Ok(enitity);
        }

        [HttpGet("active/{isActive:alpha}")]
        public ActionResult GetByActive(bool isActive)
        {
            var entites = repository.GetByActive(isActive);
            return Ok(entites);
        }*/
    }
}
