using MessagingService.DTOs.UserDTOs;
using MessagingService.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MessagingService.Controllers
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
        public ActionResult GetAll()
        {
            var users = repository.GetAll();
            if(users.Count < 0)
                return NoContent();
            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public ActionResult GetByUserId(int id)
        {
            var user = repository.GetById(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public ActionResult CreateUser(UserCreateDTO userDTO)
        {
            if (userDTO == null)
            {
                return BadRequest();
            }

            repository.CreateUser(userDTO);
            return Ok(new { message = "User created" });
        }

        [HttpPut]
        public ActionResult UpdateUser(int id, UserCreateDTO userDTO)
        {
            if (id < 0 || userDTO == null)
            {
                return BadRequest();
            }
            repository.UpdateUser(id, userDTO);
            var updated = GetByUserId(id);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            var user = repository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            repository.DeleteUser(id);
            return Ok(new { message = "User deleted" });
        }
    }
}
