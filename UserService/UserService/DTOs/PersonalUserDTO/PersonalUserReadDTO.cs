namespace UserService.DTOs.PersonalUserDTO
{
    public class PersonalUserReadDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Contact { get; set; }
        public bool isActive { get; set; }
        public string Role { get; set; }

    }
}
