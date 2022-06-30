using MessagingService.DTOs.UserGroupChat;
using MessagingService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MessagingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGroupChatController : ControllerBase
    {
        private readonly IUserGroupChatRepository rep;

        public UserGroupChatController(IUserGroupChatRepository rep)
        {
            this.rep = rep;
        }

        [HttpPost]
        public ActionResult AddUserToGroupChat(UserGroupChatCreate ugcDTO)
        {
            if (ugcDTO.UserId < 0 || ugcDTO.GroupChatId < 0)
                return BadRequest();
            rep.AddUserToGroup(ugcDTO);
            return Ok(ugcDTO);
        }

        [HttpDelete]
        public ActionResult RemoveUserFromGroup(UserGroupChatCreate ugcDTO)
        {
            if (ugcDTO.UserId < 0 || ugcDTO.GroupChatId < 0)
                return BadRequest();
            rep.DeleteUserFromGroupChat(ugcDTO);
            return Ok(new {message = "User" + ugcDTO.UserId + " deleted from group " + ugcDTO.GroupChatId});
        }
        
    }
}
