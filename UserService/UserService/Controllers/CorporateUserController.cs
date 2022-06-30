using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UserService.DTOs.CorporateUserDTO;
using UserService.Repositories.Implementation;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorporateUserController : ControllerBase
    {
        private readonly ICorporateUserRepository repository;

        public CorporateUserController(ICorporateUserRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var corporate = repository.GetAllCorporateUsers();
            if (corporate.Count() <0)
                return NotFound();
            return Ok(corporate);

        }

        [HttpGet]
        [Route("GetByCorporateUserId/{id}")]
        public ActionResult GetById(int id)
        {
            var corporate = repository.GetCorporateUserById(id);
            if (corporate == null)
                return NotFound();
            return Ok(corporate);
        }

        [HttpPost]
        public ActionResult AddCorporateUser(CorporateUserCreateDTO cUser)
        {
            if (cUser == null)
            {
                return BadRequest();
            }

            repository.CreateCorporateUser(cUser);
            return Ok(new { message = "Corporate user created" });
        }

        [HttpPut]
        public ActionResult UpdateCorporateUser(int id, CorporateUserCreateDTO cUser)
        {
            if (id < 0 || cUser == null)
            {
                return BadRequest();
            }
            var userE = repository.GetCorporateUserById(id);
            if (userE == null)
                return NotFound();
            repository.UpdateCorporatelUser(id, cUser);
            return Ok(new { message = "Corporate user updated" });
        }

        [HttpDelete]
        public ActionResult DeleteCorporateUser(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            var user = repository.GetCorporateUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            repository.DeleteCorporateUser(id);
            return Ok(new { message = "Corporate user deleted" });
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
        [Route("GetCorporateUsersByIsActive/{isActive}")]
        public ActionResult GetByContact(bool isActive)
        {
            var users = repository.GetCorporateUsersByActive(isActive);
            if (users.Count < 0)
                return NotFound("Not found");
            return Ok(users);
        }

        [HttpGet]
        [Route("GetByCorporationName/{corporationName}")]
        public ActionResult GetByCorporationname(string corporationName)
        {
            var users = repository.GetByCorporationName(corporationName);
            if (users == null)
                return NotFound();
            return Ok(users);
        }

        [HttpGet]
        [Route("GetByCompanyPIB/{PIB}")]
        public ActionResult GetByCompanyPIB(string PIB)
        {
            var users = repository.GetByPIB(PIB);
            if (users == null)
                return NotFound();
            return Ok(users);
        }
    }
}
