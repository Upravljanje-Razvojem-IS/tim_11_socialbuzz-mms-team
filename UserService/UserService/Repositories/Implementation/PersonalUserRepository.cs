using System.Collections.Generic;
using System.Linq;
using UserService.Attributes;
using UserService.DTOs.PersonalUserDTO;
using UserService.Entities;

namespace UserService.Repositories.Implementation
{
    public class PersonalUserRepository : IPersonalUserRepository
    {
        private readonly DataContext context;

        public PersonalUserRepository(DataContext context)
        {
            this.context = context;
        }

        public PersonalUserCreateDTO CreatePersonalUser(PersonalUserCreateDTO personalUser)
        {
            var userEF = new PersonalUser();
            if (UsernameExists(personalUser.Username) || EmailExists(personalUser.Email) || ContactExists(personalUser.Contact))
                throw new UniqueException("Must be unique");
            userEF.Username = personalUser.Username;
            userEF.Email = personalUser.Email;
            userEF.RoleId = 2;
            userEF.Contact = personalUser.Contact;
            userEF.isActive = personalUser.isActive;
            userEF.FirstName = personalUser.FirstName;
            userEF.LastName = personalUser.LastName;
            context.Add(userEF);
            context.SaveChanges();
            return personalUser;
        }

        public void DeletePersonalUser(int id)
        {
            var user = context.PersonalUsers.Find(id);
            if (user == null)
                throw new Attributes.KeyNotFoundException();
            context.PersonalUsers.Remove(user);
            context.SaveChanges();
        }

        public List<PersonalUserReadDTO> GetAllPersonalUsers()
        {
            var users = context.PersonalUsers.ToList();
            if (users == null)
                throw new AppException("No users in database");
            var usersDTO = users.Select(u => new PersonalUserReadDTO
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                Id = u.Id,
                Username = u.Username,
                Email = u.Email,
                Contact = u.Contact,
                isActive = u.isActive,
                Role = context.Roles.Find(u.RoleId).RoleName
            }).ToList();

            return usersDTO;

        }

        public PersonalUserReadDTO GetPersonalUserById(int id)
        {
            var user = context.PersonalUsers.Find(id);
            if(user == null)
                throw new Attributes.KeyNotFoundException("Not found with Id");
            var pUserDTO = new PersonalUserReadDTO();
            pUserDTO.FirstName = user.FirstName;
            pUserDTO.LastName = user.LastName;
            pUserDTO.Id = user.Id;
            pUserDTO.Username = user.Username;
            pUserDTO.Email = user.Email;
            pUserDTO.Contact = user.Contact;
            pUserDTO.isActive = user.isActive;
            pUserDTO.Role = context.Roles.Find(user.RoleId).RoleName;

            return pUserDTO;

        }

        public PersonalUserCreateDTO UpdatePersonalUser(int id, PersonalUserCreateDTO personalUser)
        {
            var userEF = context.PersonalUsers.Find(id);
            if (userEF == null)
                throw new Attributes.KeyNotFoundException("Not found");
            if (UsernameExists(personalUser.Username) || EmailExists(personalUser.Email) || ContactExists(personalUser.Contact))
                throw new UniqueException("Must be unique, already exists");
            userEF.Username = personalUser.Username;
            userEF.Email = personalUser.Email;
            userEF.isActive = personalUser.isActive;
            userEF.Contact = personalUser.Contact;
            userEF.RoleId = 2;
            userEF.FirstName = personalUser.FirstName;
            userEF.LastName = personalUser.LastName;
            context.Users.Update(userEF);
            context.SaveChanges();
            return personalUser;
        }

        

        public PersonalUserReadDTO GetByUsername(string username)
        {
            var user = context.PersonalUsers.FirstOrDefault(u => u.Username == username); ;
            if (user == null)
                throw new Attributes.KeyNotFoundException("User not found");
            var pUserReadDTO = new PersonalUserReadDTO();
            pUserReadDTO.Id = user.Id;
            pUserReadDTO.Username = user.Username;
            pUserReadDTO.Email = user.Email;
            pUserReadDTO.Contact = user.Contact;
            pUserReadDTO.isActive = user.isActive;
            pUserReadDTO.Role = context.Roles.Find(user.RoleId).RoleName;
            pUserReadDTO.FirstName = user.FirstName;
            pUserReadDTO.LastName = user.LastName;

            return pUserReadDTO;
        }

        public PersonalUserReadDTO GetByContact(string contact)
        {
            var user = context.PersonalUsers.FirstOrDefault(u => u.Contact == contact); ;
            if (user == null)
                throw new Attributes.KeyNotFoundException("User not found");
            var pUserReadDTO = new PersonalUserReadDTO();
            pUserReadDTO.Id = user.Id;
            pUserReadDTO.Username = user.Username;
            pUserReadDTO.Email = user.Email;
            pUserReadDTO.Contact = user.Contact;
            pUserReadDTO.isActive = user.isActive;
            pUserReadDTO.Role = context.Roles.Find(user.RoleId).RoleName;
            pUserReadDTO.FirstName = user.FirstName;
            pUserReadDTO.LastName = user.LastName;

            return pUserReadDTO;
        }

        public PersonalUserReadDTO GetByEmail(string email)
        {
            var user = context.PersonalUsers.FirstOrDefault(u => u.Email == email); ;
            if (user == null)
                throw new Attributes.KeyNotFoundException("User not found");
            var pUserReadDTO = new PersonalUserReadDTO();
            pUserReadDTO.Id = user.Id;
            pUserReadDTO.Username = user.Username;
            pUserReadDTO.Email = user.Email;
            pUserReadDTO.Contact = user.Contact;
            pUserReadDTO.isActive = user.isActive;
            pUserReadDTO.Role = context.Roles.Find(user.RoleId).RoleName;
            pUserReadDTO.FirstName = user.FirstName;
            pUserReadDTO.LastName = user.LastName;

            return pUserReadDTO;
        }

        public List<PersonalUserReadDTO> GetPersonalUsersByActive(bool isActive)
        {
            var users = context.PersonalUsers.Where(u => u.isActive == isActive).ToList();
            if (users == null)
                throw new AppException("No users in database");
            var usersDTO = users.Select(u => new PersonalUserReadDTO
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Username = u.Username,
                Email = u.Email,
                Contact = u.Contact,
                isActive = u.isActive,
                Role = context.Roles.Find(u.RoleId).RoleName
            }).ToList();

            return usersDTO;
        }

        public List<PersonalUserReadDTO> GetPersonalUsersByFirstName(string firstName)
        {
            var users = context.PersonalUsers.Where(u => u.FirstName == firstName).ToList();
            if (users == null)
                throw new AppException("No users in database");
            var usersDTO = users.Select(u => new PersonalUserReadDTO
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Username = u.Username,
                Email = u.Email,
                Contact = u.Contact,
                isActive = u.isActive,
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

        public List<PersonalUserReadDTO> GetPersonalUsersByLastName(string lastName)
        {
            var users = context.PersonalUsers.Where(u => u.LastName == lastName).ToList();
            if (users == null)
                throw new AppException("No users in database");
            var usersDTO = users.Select(u => new PersonalUserReadDTO
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Username = u.Username,
                Email = u.Email,
                Contact = u.Contact,
                isActive = u.isActive,
                Role = context.Roles.Find(u.RoleId).RoleName
            }).ToList();

            return usersDTO;
        }
    }
}
