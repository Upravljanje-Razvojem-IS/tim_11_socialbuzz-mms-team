using Microsoft.AspNetCore.Mvc;
using UserContentService.DTOs;
using UserContentService.Repositories;

namespace UserContentService.Controllers
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
            if (users.Count == 0)
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

            repository.Create(userDTO);
            return Ok(new { message = "User created" });
        }

        [HttpPut]
        public ActionResult UpdateUser(int id, UserCreateDTO userDTO)
        {
            if (id == null || userDTO == null)
            {
                return BadRequest();
            }
            repository.Update(id, userDTO);
            var updated = GetByUserId(id);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public IActionResult delete(int id)
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
            repository.Delete(id);
            return Ok(new { message = "User deleted" });
        }

       /* [HttpGet]
        [Route("GetAllAdsAndContentsByUser/{username}")]
        public ActionResult GetAllAdsAndContentsByUser(string username)
        {
            if(username == null)
                return BadRequest();
            var ct = repository.GetAllAdsAndContentsByUser(username);
            if (ct == null)
                return NotFound();
            return Ok(ct);
        }*/
    }
}
