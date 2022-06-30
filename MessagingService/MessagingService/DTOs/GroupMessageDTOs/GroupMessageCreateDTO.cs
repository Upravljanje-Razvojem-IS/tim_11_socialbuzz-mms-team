namespace MessagingService.DTOs.GroupMessageDTOs
{
    public class GroupMessageCreateDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int SenderId { get; set; }

        public int GroupChatId { get; set; }
    }
}
