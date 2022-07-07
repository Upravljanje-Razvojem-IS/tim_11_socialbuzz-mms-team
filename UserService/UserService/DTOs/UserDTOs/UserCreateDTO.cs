namespace UserService.DTOs.UserDTOs
{
    public class UserCreateDTO
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public bool IsActive { get; set; }
    }
}
