using MessagingService.DTOs.GroupChatDTOs;
using MessagingService.DTOs.UserDTOs;
using System;
using System.Collections.Generic;

namespace MessagingService.DTOs.GroupMessageDTOs
{
    public class GroupMessageReadDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public UserReadDTO Sender { get; set; }

        public List<UserReadDTO> Recievers { get; set; }

        public string GroupChatName { get; set; }
    }
}
