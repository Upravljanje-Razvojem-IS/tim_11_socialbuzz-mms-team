namespace UserService.DTOs.CorporateUserDTO
{
    public class CorporateUserCreateDTO
    {
        public string CorporationName { get; set; }
        public string PIB { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Contact { get; set; }
        public bool isActive { get; set; }
    }
}
