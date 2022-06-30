using MessagingService.DTOs.GroupMessageDTOs;
using MessagingService.DTOs.UserDTOs;
using System.Collections.Generic;

namespace MessagingService.DTOs.GroupChatDTOs
{
    public class GroupChatReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GroupMessageReadDTO> GroupMessages { get; set; }
        public List<UserReadDTO> Users { get; set; }
    }
}
