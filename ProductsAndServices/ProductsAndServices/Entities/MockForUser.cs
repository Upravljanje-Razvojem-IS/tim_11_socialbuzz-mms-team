using System.Collections.Generic;

namespace ProductsAndServices.Entities
{
    public class MockForUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }
    }

    public static class MockUserData
    {
        public static List<MockForUser> Users = new List<MockForUser>(){
            new MockForUser()
            {
                Id = 1,
                FirstName = "Lazar",
                LastName = "Lazarevic",
                Email = "laza.lazarevic@gmail.com"
            },

            new MockForUser()
            {
                Id = 2,
                FirstName = "Milos",
                LastName = "Milosevic",
                Email = "milos.milosevic@yahoo.com"
            }
        };
    }
}
