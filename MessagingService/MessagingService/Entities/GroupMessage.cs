using System;
using System.Collections.Generic;

namespace MessagingService.Entities
{
    public class GroupMessage
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public int SenderId { get; set; }

        public List<User> Recievers { get; set; }

        public int GroupChatId { get; set; }
        public virtual GroupChat GroupChat { get; set; }

        public GroupMessage()
        {
            this.Recievers = new List<User>();
        }

    }
}
