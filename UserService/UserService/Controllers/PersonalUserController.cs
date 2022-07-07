using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UserService.DTOs.PersonalUserDTO;
using UserService.Entities;
using UserService.Repositories;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalUserController : ControllerBase
    {
        
        private readonly IPersonalUserRepository repository;

        public PersonalUserController(IPersonalUserRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var personal = repository.GetAllPersonalUsers();
            if(personal.Count() < 0)
                return NotFound();
            return Ok(personal);

        }

        [HttpGet]
        [Route("GetByPersonalUserId/{id}")]
        public ActionResult GetById(int id)
        {
            var user = repository.GetPersonalUserById(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public ActionResult AddPersonalUser(PersonalUserCreateDTO user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            repository.CreatePersonalUser(user);
            return Ok(new { message = "User created" });
        }

        [HttpPut]
        public ActionResult UpdatePersonal(int id, PersonalUserCreateDTO user)
        {
            if (id < 0 || user == null)
            {
                return BadRequest();
            }
            var userE = repository.GetPersonalUserById(id);
            if (userE == null)
                return NotFound();
            repository.UpdatePersonalUser(id, user);
            return Ok(new { message = "Personal user updated" });
        }

        [HttpDelete]
        public ActionResult DeletePersonalUser(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            var user = repository.GetPersonalUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            repository.DeletePersonalUser(id);
            return Ok(new { message = "Personal user deleted" });
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
        [Route("GetPersonalUsersByIsActive/{isActive}")]
        public ActionResult GetByContact(bool isActive)
        {
            var users = repository.GetPersonalUsersByActive(isActive);
            if (users.Count() < 0)
                return NotFound();
            return Ok(users);
        }

        [HttpGet]
        [Route("GetPersonalUsersByFirstName/{firstName}")]
        public ActionResult GetPersonalUsersByFirstName(string firstName)
        {
            var users = repository.GetPersonalUsersByFirstName(firstName);
            if (users == null)
                return NotFound();
            return Ok(users);
        }

        [HttpGet]
        [Route("GetPersonalUsersByLastName/{lastName}")]
        public ActionResult GetUsersByLastName(string lastName)
        {
            var users = repository.GetPersonalUsersByLastName(lastName);
            if (users == null)
                return NotFound();
            return Ok(users);
        }


    }
}
