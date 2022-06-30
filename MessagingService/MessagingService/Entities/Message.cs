using System;

namespace MessagingService.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public int SenderId { get; set; }
        public int RecieverId { get; set; }
        
        public int ChatId { get; set; }
        public virtual Chat Chat { get; set; }
    }
}
