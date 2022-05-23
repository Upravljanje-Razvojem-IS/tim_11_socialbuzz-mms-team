using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext context;

        public UserController(DataContext context)
        {
            this.context = context;
        }

        /*[HttpGet]
        public async Task<ActionResult<List<UserModel>>> getAll()
        {
            var result = await context.users.ToListAsync();

            return Ok(result);
        }*/

        [HttpGet]
        public ActionResult<List<UserModel>> getAll(string usernmae)
        {
            var result = context.users.toList();

            return Ok(result);
        }
        
    }
}
