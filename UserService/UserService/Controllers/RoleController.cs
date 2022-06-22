using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.DTOs.RoleDTOs;
using UserService.Repositories;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var roles = roleRepository.GetAll();
            if(roles == null)
                return NotFound();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public ActionResult GetRoleById(int id)
        {
            var role = roleRepository.GetById(id);
            if (role == null)
                return NotFound();

            return Ok(role);
        }

        [HttpGet("GetByRolename/{RoleName}")]
        public ActionResult GetByRoleName(string roleName)
        {
            var role = roleRepository.GetByRoleName(roleName);
            if(role == null)
                return NotFound();

            return Ok(role);
        }

        [HttpPost]
        public ActionResult AddRole(RoleCreateDTO role)
        {
            if(role == null)
            {
                return BadRequest();
            }

            roleRepository.CreateRole(role);
            return Ok(new { message = "Role created" });
        }

        [HttpPut]
        public ActionResult UpdateRole(int id, RoleCreateDTO role)
        {
            if(id == null || role == null)
            {
                return BadRequest();
            }
            roleRepository.UpdateRole(id, role);
            return Ok(new { message = "Model updated" });
        }

        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            var role = roleRepository.GetById(id);
            if (role == null)
            {
                return NotFound();
            }
            roleRepository.DeleteRole(id);
            return Ok(new { message = "Role deleted" });
        }

    }
}
