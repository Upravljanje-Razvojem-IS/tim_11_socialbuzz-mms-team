using Microsoft.AspNetCore.Mvc;
using UserService.DTOs.UserDTOs;
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
        public ActionResult GetAll()
        {
            var users = repository.GetAllUsers();
            if(users == null)
                return NotFound();
            return Ok(users);
        }

        [HttpGet]
        [Route("GetByUserId/{id}")]
        public ActionResult GetById(int id)
        {
            var user = repository.GetById(id);
            if(user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public ActionResult AddAdmin(UserCreateDTO user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            repository.CreateAdmin(user);
            return Ok(new { message = "Admin created" });
        }

        [HttpPut]
        public ActionResult UpdateAdmin(int id, UserCreateDTO user)
        {
            if(id == null || user == null)
            {
                return BadRequest();
            }
            var userE = repository.GetById(id);
            if (userE == null)
                return NotFound();
            repository.UpdateAdmin(id, user);
            return Ok(new { message = "Admin updated" });
        }

        [HttpDelete]
        public ActionResult DeleteUser(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var user = repository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            repository.DeleteAdmin(id);
            return Ok(new { message = "Admin deleted" });
        }

        [HttpGet]
        [Route("GetByUsername/{username}")]
        public ActionResult GetByUsername(string username)
        {
            var user = repository.GetByUsername(username);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpGet]
        [Route("GetByEmail/{email}")]
        public ActionResult GetByEmail(string email)
        {
            var user = repository.GetByEmail(email);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpGet]
        [Route("GetByContact/{contact}")]
        public ActionResult GetByContact(string contact)
        {
            var user = repository.GetByContact(contact);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpGet]
        [Route("GetUsersByIsActive/{isActive}")]
        public ActionResult GetByContact(bool isActive)
        {
            var users = repository.GetUsersByActive(isActive);
            if (users == null)
                return NotFound();
            return Ok(users);
        }

        [HttpGet]
        [Route("GetUsersByRole/{role}")]
        public ActionResult GetUsersByRole(string role)
        {
            var users = repository.GetUsersByRole(role);
            if (users == null)
                return NotFound();
            return Ok(users);
        }




    }
}
