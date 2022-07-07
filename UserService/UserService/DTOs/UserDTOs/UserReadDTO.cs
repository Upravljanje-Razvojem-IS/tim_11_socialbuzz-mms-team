namespace UserService.DTOs.UserDTOs
{
    public class UserReadDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public bool IsActive { get; set; }
        public string Role { get; set; }
    }
}
