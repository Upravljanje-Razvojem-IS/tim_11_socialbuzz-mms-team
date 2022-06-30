using MessagingService.DTOs.GroupMessageDTOs;
using MessagingService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MessagingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupMessagesController : ControllerBase
    {
        private readonly IGroupMessageRepository repository;

        public GroupMessagesController(IGroupMessageRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var gm = repository.GetAll();
            if(gm.Count < 0)
                return NotFound();
            return Ok(gm);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var gm = repository.GetById(id);
            if(gm == null)
                return NotFound();
            return Ok(gm);
        }

        [HttpPost]
        public ActionResult Create(GroupMessageCreateDTO mDTO)
        {
            if (mDTO == null)
                return BadRequest();
            repository.Create(mDTO);
            return Ok(mDTO);
        }

        [HttpPut]
        public ActionResult Update(int id, GroupMessageCreateDTO mDTO)
        {
            if (id < 0 || mDTO == null)
                return BadRequest();
            repository.Update(id, mDTO);
            return Ok(mDTO);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if(id < 0)
                return BadRequest();
            repository.Delete(id);
            return Ok(new { message = "Group message deleted" });
        }
    }
}
