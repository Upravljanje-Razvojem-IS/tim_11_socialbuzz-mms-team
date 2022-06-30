using MessagingService.DTOs.MessageDTOs;
using MessagingService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MessagingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageRepository repository;

        public MessageController(IMessageRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var messages = repository.GetAll();
            if(messages.Count() < 0)
                return NotFound();
            return Ok(messages);
        }

        [HttpGet]
        [Route("GetByMessageId/{id}")]
        public ActionResult GetById(int id)
        {
            var message = repository.GetById(id);
            if (message == null)
                return NotFound();
            return Ok(message);
        }

        [HttpPost]
        public ActionResult CreateMessage(MessageCreateDTO messageDTO)
        {
            if (messageDTO == null)
                return BadRequest();
            repository.Create(messageDTO);
            return Ok(messageDTO);
        }

        [HttpPut]
        public ActionResult UpdateMessage(int id, MessageCreateDTO messageDTO)
        {
            if (id <0 || messageDTO == null)
                return BadRequest();
            var message = repository.GetById(id);
            if (message == null)
                return NotFound();
            repository.Update(id, messageDTO);
            return Ok(messageDTO);
        }

        [HttpDelete]
        public ActionResult DeleteMessage(int id)
        {
            if (id <0)
                return BadRequest();
            var message = repository.GetById(id);
            if (message == null)
                return NotFound();
            repository.Delete(id);
            return Ok(new { message = "Message deleted" });
        }

    }
}
