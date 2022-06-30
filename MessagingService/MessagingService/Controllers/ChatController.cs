using MessagingService.DTOs.ChatDTOs;
using MessagingService.Entities;
using MessagingService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MessagingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatRepository repository;

        public ChatController(IChatRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var chats = repository.GetAll();
            if(chats.Count == 0)
                return NotFound();
            return Ok(chats);
        }


        [HttpGet]
        [Route("GetByChatId/{id}")]
        public ActionResult GetById(int id)
        {
            var chat = repository.GetById(id);
            if(chat == null)
                return NotFound();
            return Ok(chat);
        }

        [HttpPost]
        public ActionResult CreateChat(ChatCreateDTO chat)
        {
            if (chat == null)
                return BadRequest();
            repository.CreateChat(chat);
            return Ok(chat);
        }

        [HttpPut]
        public ActionResult UpdateChat(int id, ChatCreateDTO chatDTO)
        {
            if (id < 0 || chatDTO == null)
                return BadRequest();
            var chat = repository.GetById(id);
            if (chat == null)
                return NotFound();
            repository.UpdateChat(id, chatDTO);
            return Ok(chatDTO);
        }

        [HttpDelete]
        public ActionResult DeleteChat(int id)
        {
            if (id < 0)
                return BadRequest();
            var chat = repository.GetById(id);
            if (chat == null)
                return NotFound();
            repository.DeleteChat(id);
            return Ok(new { message = "Chat deleted" });
        }
    }
}
