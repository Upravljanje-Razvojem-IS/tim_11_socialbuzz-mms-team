using System.Collections.Generic;
using System.Linq;
using UserService.Attributes;
using UserService.DTOs.UserDTOs;
using UserService.Entities;

namespace UserService.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext context;

        public UserRepository(DataContext context)
        {
            this.context = context;
        }        

        public void DeleteAdmin(int id)
        {
            var user = context.Users.Find(id);
            if (user == null)
                throw new Attributes.KeyNotFoundException();
            context.Users.Remove(user);
            context.SaveChanges();
        }

       

        public UserReadDTO GetById(int id)
        {
            var user = context.Users.Find(id);
            if (user == null)
                throw new Attributes.KeyNotFoundException("User not found");
            var userReadDTO = new UserReadDTO();
            userReadDTO.Id = id;
            userReadDTO.Username = user.Username;
            userReadDTO.Email = user.Email;
            userReadDTO.Contact = user.Contact;
            userReadDTO.IsActive = user.isActive;
            userReadDTO.Role = context.Roles.Find(user.RoleId).RoleName;

            return userReadDTO;
        }

        public List<UserReadDTO> GetAllUsers()
        {
            var users = context.Users.ToList();
            if (users == null)
                throw new AppException("No users in database");
            var usersDTO = users.Select(u => new UserReadDTO
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email,
                Contact = u.Contact,
                IsActive = u.isActive,
                Role = context.Roles.Find(u.RoleId).RoleName
            }).ToList();

            return usersDTO;
        }

        public UserCreateDTO CreateAdmin(UserCreateDTO userCreateDTO)
        {
            var userEF = new User();
            if (UsernameExists(userCreateDTO.Username) || EmailExists(userCreateDTO.Email) || ContactExists(userCreateDTO.Contact))
                throw new UniqueException("Must be unique");
            userEF.Username = userCreateDTO.Username;
            userEF.Email = userCreateDTO.Email;
            userEF.RoleId = 1;
            userEF.Contact = userCreateDTO.Contact;
            userEF.isActive = userCreateDTO.IsActive;
            context.Add(userEF);
            context.SaveChanges();
            return userCreateDTO;
        }

        public UserCreateDTO UpdateAdmin(int id, UserCreateDTO userCreateDTO)
        {
            var userEF = context.Users.Find(id);
            if (userEF == null)
                throw new Attributes.KeyNotFoundException("Not found");
            if (UsernameExists(userCreateDTO.Username) || EmailExists(userCreateDTO.Email) || ContactExists(userCreateDTO.Contact))
                throw new UniqueException("Must be unique, already exists");
            userEF.Username = userCreateDTO.Username;
            userEF.Email = userCreateDTO.Email;
            userEF.isActive = userCreateDTO.IsActive;
            userEF.Contact = userCreateDTO.Contact;
            userEF.RoleId = 1;
            context.Users.Update(userEF);
            context.SaveChanges();
            return userCreateDTO;
        }

        public UserReadDTO GetByUsername(string username)
        {
            var user = context.Users.FirstOrDefault(u => u.Username == username); ;
            if (user == null)
                throw new Attributes.KeyNotFoundException("User not found");
            var userReadDTO = new UserReadDTO();
            userReadDTO.Id = user.Id;
            userReadDTO.Username = user.Username;
            userReadDTO.Email = user.Email;
            userReadDTO.Contact = user.Contact;
            userReadDTO.IsActive = user.isActive;
            userReadDTO.Role = context.Roles.Find(user.RoleId).RoleName;

            return userReadDTO;
        }

        public UserReadDTO GetByContact(string contact)
        {
            var user = context.Users.FirstOrDefault(u => u.Contact == contact); ;
            if (user == null)
                throw new Attributes.KeyNotFoundException("User not found");
            var userReadDTO = new UserReadDTO();
            userReadDTO.Id = user.Id;
            userReadDTO.Username = user.Username;
            userReadDTO.Email = user.Email;
            userReadDTO.Contact = user.Contact;
            userReadDTO.IsActive = user.isActive;
            userReadDTO.Role = context.Roles.Find(user.RoleId).RoleName;

            return userReadDTO;
        }

        public UserReadDTO GetByEmail(string email)
        {
            var user = context.Users.FirstOrDefault(u => u.Email == email); ;
            if (user == null)
                throw new Attributes.KeyNotFoundException("User not found");
            var userReadDTO = new UserReadDTO();
            userReadDTO.Id = user.Id;
            userReadDTO.Username = user.Username;
            userReadDTO.Email = user.Email;
            userReadDTO.Contact = user.Contact;
            userReadDTO.IsActive = user.isActive;
            userReadDTO.Role = context.Roles.Find(user.RoleId).RoleName;

            return userReadDTO;
        }

        public List<UserReadDTO> GetUsersByActive(bool isActive)
        {
            var users = context.Users.Where(u => u.isActive == isActive).ToList();
            if (users == null)
                throw new AppException("No users in database");
            var usersDTO = users.Select(u => new UserReadDTO
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email,
                Contact = u.Contact,
                IsActive = u.isActive,
                Role = context.Roles.Find(u.RoleId).RoleName
            }).ToList();

            return usersDTO;
        }

        public List<UserReadDTO> GetUsersByRole(string role)
        {
            var users = context.Users.Where(u => u.Role.RoleName == role).ToList();
            if (users == null)
                throw new AppException("No users in database");
            var usersDTO = users.Select(u => new UserReadDTO
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email,
                Contact = u.Contact,
                IsActive = u.isActive,
                Role = context.Roles.Find(u.RoleId).RoleName
            }).ToList();

            return usersDTO;
        }


        private bool UsernameExists(string username)
        {
            bool user = context.Users.Any(u => u.Username == username);
            bool userP = context.PersonalUsers.Any(u => u.Username == username);
            bool userC = context.CorporateUsers.Any(u => u.Username == username);
            if (user || userP || userC)
                return true;
            return false;
        }

        private bool EmailExists(string email)
        {
            bool user = context.Users.Any(u => u.Email == email);
            bool userP = context.PersonalUsers.Any(u => u.Email == email);
            bool userC = context.CorporateUsers.Any(u => u.Email == email);
            if (user || userP || userC)
                return true;
            return false;
        }

        private bool ContactExists(string contact)
        {
            bool user = context.Users.Any(u => u.Contact == contact);
            bool userP = context.PersonalUsers.Any(u => u.Contact == contact);
            bool userC = context.CorporateUsers.Any(u => u.Contact == contact);
            if (user || userP || userC)
                return true;
            return false;
        }


    }
}
