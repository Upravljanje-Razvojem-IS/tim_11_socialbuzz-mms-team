using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UserService.Entities;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalUserController : ControllerBase
    {
        private readonly DataContext context;

        public PersonalUserController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var personal = context.PersonalUsers.ToList();
            return Ok(personal);

        }


    }
}
