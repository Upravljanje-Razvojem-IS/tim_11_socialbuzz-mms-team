namespace MessagingService.DTOs.ChatDTOs
{
    public class ChatCreateDTO
    {
        public string ChatName { get; set; }
        public int FirstUserId { get; set; }
        public int SecondUserId { get; set; }
    }
}
