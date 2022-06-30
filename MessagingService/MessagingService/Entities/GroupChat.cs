using System.Collections.Generic;

namespace MessagingService.Entities
{
    public class GroupChat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GroupMessage> groupMessages { get; set; }
        public List<User> Users { get; set; }

        public GroupChat()
        {
            this.groupMessages = new List<GroupMessage>();
            this.Users = new List<User>();
        }
    }
}
