using MessagingService.DTOs.MessageDTOs;
using MessagingService.DTOs.UserDTOs;
using System.Collections.Generic;

namespace MessagingService.DTOs.ChatDTOs
{
    public class ChatReadDTO
    {
        public int Id { get; set; }
        public string ChatName { get; set; }
        public UserReadDTO FirstUser { get; set; }
        public UserReadDTO SecondUser { get; set; }
        public List<MessageReadDTO> Messages { get; set; }
    }
}
