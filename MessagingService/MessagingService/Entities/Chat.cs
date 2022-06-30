using System.Collections.Generic;

namespace MessagingService.Entities
{
    public class Chat
    {
        public int Id { get; set; }
        public string ChatName { get; set; }
        public int FirstUserId { get; set; }
        public int SecondUserId { get; set; }
        public List<Message> Messages { get; set; }


        public Chat()
        {
            this.Messages = new List<Message>();
        }
    }
}
