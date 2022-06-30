namespace MessagingService.DTOs.MessageDTOs
{
    public class MessageCreateDTO
    {
      
        public string Text { get; set; }
        public int SenderId { get; set; }
        public int RecieverId { get; set; }
        public int ChatId { get; set; }
    }
}
