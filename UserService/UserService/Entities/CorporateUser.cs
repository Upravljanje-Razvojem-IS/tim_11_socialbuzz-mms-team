namespace UserService.Entities
{
    public class CorporateUser: User
    { 
        public string CorporationName { get; set; }
        public string PIB { get; set; }
    }
}
