using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAndServices.Entities
{
    public class MockForUser
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }
    }

    public static class MockUserData
    {
        public static List<MockForUser> Users = new List<MockForUser>(){
            new MockForUser()
            {
                FirstName = "Lazar",
                LastName = "Lazarevic",
                Email = "laza.lazarevic@gmail.com"
            },

            new MockForUser()
            {
                FirstName = "Milos",
                LastName = "Milosevic",
                Email = "milos.milosevic@yahoo.com"
            }
        };
    }
}
