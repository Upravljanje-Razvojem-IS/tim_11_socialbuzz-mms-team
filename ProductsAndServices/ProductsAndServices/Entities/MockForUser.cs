﻿using System.Collections.Generic;

namespace ProductsAndServices.Entities
{
    /// <summary>
    /// Mock For User model
    /// </summary>
    public class MockForUser
    {
        /// <summary>
        /// Id of mock user
        /// </summary>
        public int MockUserId { get; set; }
        /// <summary>
        /// First name of mock user
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of mock user
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Email of mock user
        /// </summary>
        public string Email { get; set; }
    }

    public static class MockUserData
    {
        public static List<MockForUser> MockUsers = new List<MockForUser>(){
            new MockForUser()
            {
                MockUserId = 1,
                FirstName = "Lazar",
                LastName = "Lazarevic",
                Email = "laza.lazarevic@gmail.com"
            },

            new MockForUser()
            {
                MockUserId = 2,
                FirstName = "Milos",
                LastName = "Milosevic",
                Email = "milos.milosevic@yahoo.com"
            }
        };
    }
}