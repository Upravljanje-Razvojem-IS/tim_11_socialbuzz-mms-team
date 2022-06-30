using MessagingService.DTOs.UserDTOs;
using MessagingService.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MessagingService.Repositories.impl
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext context;

        public UserRepository(DataContext context)
        {
            this.context = context;
        }

        public UserCreateDTO CreateUser(UserCreateDTO userDTO)
        {
            var userEF = new User();
            userEF.Username = userDTO.Username;
            context.Users.Add(userEF);
            context.SaveChanges();
            return userDTO;
        }

        public void DeleteUser(int id)
        {
            var user = context.Users.Find(id);
            if (user == null)
                throw new System.Exception("Not found");
            context.Users.Remove(user);
            context.SaveChanges();
        }

        public List<UserReadDTO> GetAll()
        {
            var users = context.Users.ToList();
            if (users.Count() == 0)
                throw new System.Exception("No users");
            var usersDTO = users.Select(users => new UserReadDTO
            {
                Id = users.Id,
                Username = users.Username,
            }).ToList();
            return usersDTO;
            
        }

        public UserReadDTO GetById(int id)
        {
            var user = context.Users.Find(id);
            if (user == null)
                throw new System.Exception("Not found");
            var userDTO = new UserReadDTO();
            userDTO.Id = user.Id;
            userDTO.Username = user.Username;
            return userDTO;
        }

        public List<UserReadDTO> GetUsersFromGroupChat(int id)
        {
            var users = context.Users.Where(u => u.Id == id).ToList();
            if (users.Count() == 0)
                throw new System.Exception("No users");
            var usersDTO = users.Select(users => new UserReadDTO
            {
                Id = users.Id,
                Username = users.Username,
            }).ToList();
            return usersDTO;
        }

        public UserReadDTO UpdateUser(int id, UserCreateDTO userDTO)
        {
            var userEF = context.Users.Find(id);
            if (userEF == null)
                throw new System.Exception("Not found");
            userEF.Username = userDTO.Username;
            context.Users.Update(userEF);
            context.SaveChanges();
            var userRD = new UserReadDTO();
            userRD.Username = userEF.Username;
            userRD.Id = userEF.Id;
            return userRD;
        }

        
    }
}
