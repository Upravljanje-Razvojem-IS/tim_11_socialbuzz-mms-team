using MessagingService.DTOs.UserDTOs;
using System;

namespace MessagingService.DTOs.MessageDTOs
{
    public class MessageReadDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public UserReadDTO Sender { get; set; }
        public  UserReadDTO Reciever { get; set; }
        public string ChatName { get; set; }
    }
}
