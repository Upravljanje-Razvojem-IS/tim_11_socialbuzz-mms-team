using MessagingService.DTOs.GroupChatDTOs;
using MessagingService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MessagingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupChatController : ControllerBase
    {
        private readonly IGroupChatRepository rep;

        public GroupChatController(IGroupChatRepository rep)
        {
            this.rep = rep;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var gc = rep.GetAll();
            if(gc.Count < 0)
                return NotFound();
            return Ok(gc);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            if (id < 0)
                return BadRequest();
            var gc = rep.GetById(id);
            if (gc == null)
                return NotFound();
            return Ok(gc);
        }

        [HttpPost]
        public ActionResult Create(GroupChatCreateDTO gcDTO)
        {
            if (gcDTO == null)
                return BadRequest();
            rep.Create(gcDTO);
            return Ok(gcDTO);
        }

        [HttpPut]
        public ActionResult Update(int id,GroupChatCreateDTO gcDTO)
        {
            if (id < 0 || gcDTO == null)
                return BadRequest();
            rep.Update(id,gcDTO);
            return Ok(gcDTO);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (id < 0)
                return BadRequest();
            rep.Delete(id);
            return Ok(new { message = "Group chat deleted" });
        }
    }
}
