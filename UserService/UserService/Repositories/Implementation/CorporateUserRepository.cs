using System.Collections.Generic;
using System.Linq;
using UserService.Attributes;
using UserService.DTOs.CorporateUserDTO;
using UserService.Entities;

namespace UserService.Repositories.Implementation
{
    public class CorporateUserRepository : ICorporateUserRepository
    {
        private readonly DataContext context;

        public CorporateUserRepository(DataContext context)
        {
            this.context = context;
        }

        public CorporateUserCreateDTO CreateCorporateUser(CorporateUserCreateDTO cUserDTO)
        {
            var userEF = new CorporateUser();
            if (UsernameExists(cUserDTO.Username) || EmailExists(cUserDTO.Email) || ContactExists(cUserDTO.Contact) || PIBExists(cUserDTO.PIB) || CorporationNameExist(cUserDTO.CorporationName))
                throw new UniqueException("Must be unique");
            userEF.Username = cUserDTO.Username;
            userEF.Email = cUserDTO.Email;
            userEF.RoleId = 2;
            userEF.Contact = cUserDTO.Contact;
            userEF.isActive = cUserDTO.isActive;
            userEF.CorporationName = cUserDTO.CorporationName;
            userEF.PIB = cUserDTO.PIB;
            context.Add(userEF);
            context.SaveChanges();
            return cUserDTO;
        }

        public void DeleteCorporateUser(int id)
        {
            var user = context.CorporateUsers.Find(id);
            if (user == null)
                throw new Attributes.KeyNotFoundException();
            context.CorporateUsers.Remove(user);
            context.SaveChanges();
        }

        public List<CorporateUserReadDTO> GetAllCorporateUsers()
        {
            var users = context.CorporateUsers.ToList();
            if (users == null)
                throw new AppException("No corporate users in database");
            var cUsersDTO = users.Select(u => new CorporateUserReadDTO
            {
                CorporationName = u.CorporationName,
                PIB = u.PIB,
                Id = u.Id,
                Username = u.Username,
                Email = u.Email,
                Contact = u.Contact,
                isActive = u.isActive,
                Role = context.Roles.Find(u.RoleId).RoleName
            }).ToList();

            return cUsersDTO;
        }

        public CorporateUserReadDTO GetByContact(string contact)
        {
            var user = context.CorporateUsers.FirstOrDefault(u => u.Contact == contact); ;
            if (user == null)
                throw new Attributes.KeyNotFoundException("Corporation not found");
            var cUserReadDTO = new CorporateUserReadDTO();
            cUserReadDTO.Id = user.Id;
            cUserReadDTO.Username = user.Username;
            cUserReadDTO.Email = user.Email;
            cUserReadDTO.Contact = user.Contact;
            cUserReadDTO.isActive = user.isActive;
            cUserReadDTO.Role = context.Roles.Find(user.RoleId).RoleName;
            cUserReadDTO.CorporationName = user.CorporationName;
            cUserReadDTO.PIB = user.PIB;

            return cUserReadDTO;
        }

        public CorporateUserReadDTO GetByCorporationName(string corporationName)
        {
            var user = context.CorporateUsers.FirstOrDefault(u => u.CorporationName == corporationName); ;
            if (user == null)
                throw new Attributes.KeyNotFoundException("Corporation not found");
            var cUserReadDTO = new CorporateUserReadDTO();
            cUserReadDTO.Id = user.Id;
            cUserReadDTO.Username = user.Username;
            cUserReadDTO.Email = user.Email;
            cUserReadDTO.Contact = user.Contact;
            cUserReadDTO.isActive = user.isActive;
            cUserReadDTO.Role = context.Roles.Find(user.RoleId).RoleName;
            cUserReadDTO.CorporationName = user.CorporationName;
            cUserReadDTO.PIB = user.PIB;

            return cUserReadDTO;
        }

        public CorporateUserReadDTO GetByEmail(string email)
        {
            var user = context.CorporateUsers.FirstOrDefault(u => u.Email == email); ;
            if (user == null)
                throw new Attributes.KeyNotFoundException("Corporation not found");
            var cUserReadDTO = new CorporateUserReadDTO();
            cUserReadDTO.Id = user.Id;
            cUserReadDTO.Username = user.Username;
            cUserReadDTO.Email = user.Email;
            cUserReadDTO.Contact = user.Contact;
            cUserReadDTO.isActive = user.isActive;
            cUserReadDTO.Role = context.Roles.Find(user.RoleId).RoleName;
            cUserReadDTO.CorporationName = user.CorporationName;
            cUserReadDTO.PIB = user.PIB;

            return cUserReadDTO;
        }

        public CorporateUserReadDTO GetByPIB(string PIB)
        {
            var user = context.CorporateUsers.FirstOrDefault(u => u.PIB == PIB); ;
            if (user == null)
                throw new Attributes.KeyNotFoundException("Corporation not found");
            var cUserReadDTO = new CorporateUserReadDTO();
            cUserReadDTO.Id = user.Id;
            cUserReadDTO.Username = user.Username;
            cUserReadDTO.Email = user.Email;
            cUserReadDTO.Contact = user.Contact;
            cUserReadDTO.isActive = user.isActive;
            cUserReadDTO.Role = context.Roles.Find(user.RoleId).RoleName;
            cUserReadDTO.CorporationName = user.CorporationName;
            cUserReadDTO.PIB = user.PIB;

            return cUserReadDTO;
        }

        public CorporateUserReadDTO GetByUsername(string username)
        {
            var user = context.CorporateUsers.FirstOrDefault(u => u.Username == username); ;
            if (user == null)
                throw new Attributes.KeyNotFoundException("Corporation not found");
            var cUserReadDTO = new CorporateUserReadDTO();
            cUserReadDTO.Id = user.Id;
            cUserReadDTO.Username = user.Username;
            cUserReadDTO.Email = user.Email;
            cUserReadDTO.Contact = user.Contact;
            cUserReadDTO.isActive = user.isActive;
            cUserReadDTO.Role = context.Roles.Find(user.RoleId).RoleName;
            cUserReadDTO.CorporationName = user.CorporationName;
            cUserReadDTO.PIB = user.PIB;

            return cUserReadDTO;
        }

        public CorporateUserReadDTO GetCorporateUserById(int id)
        {
            var user = context.CorporateUsers.Find(id); ;
            if (user == null)
                throw new Attributes.KeyNotFoundException("Corporation not found");
            var cUserReadDTO = new CorporateUserReadDTO();
            cUserReadDTO.Id = user.Id;
            cUserReadDTO.Username = user.Username;
            cUserReadDTO.Email = user.Email;
            cUserReadDTO.Contact = user.Contact;
            cUserReadDTO.isActive = user.isActive;
            cUserReadDTO.Role = context.Roles.Find(user.RoleId).RoleName;
            cUserReadDTO.CorporationName = user.CorporationName;
            cUserReadDTO.PIB = user.PIB;

            return cUserReadDTO;
        }

        public List<CorporateUserReadDTO> GetCorporateUsersByActive(bool isActive)
        {
            var users = context.CorporateUsers.Where(u => u.isActive == isActive).ToList();
            if (users == null)
                throw new AppException("No corprate users in database");
            var usersDTO = users.Select(u => new CorporateUserReadDTO
            {
                Id = u.Id,
                CorporationName = u.CorporationName,
                PIB = u.PIB,
                Username = u.Username,
                Email = u.Email,
                Contact = u.Contact,
                isActive = u.isActive,
                Role = context.Roles.Find(u.RoleId).RoleName
            }).ToList();

            return usersDTO;
        }

        public CorporateUserCreateDTO UpdateCorporatelUser(int id, CorporateUserCreateDTO cUserDTO)
        {
            var userEF = context.CorporateUsers.Find(id);
            if (userEF == null)
                throw new Attributes.KeyNotFoundException("Not found");
            if (UsernameExists(cUserDTO.Username) || EmailExists(cUserDTO.Email) || ContactExists(cUserDTO.Contact) || PIBExists(cUserDTO.PIB) || CorporationNameExist(cUserDTO.CorporationName))
                throw new UniqueException("Must be unique, already exists");
            userEF.Username = cUserDTO.Username;
            userEF.Email = cUserDTO.Email;
            userEF.isActive = cUserDTO.isActive;
            userEF.Contact = cUserDTO.Contact;
            userEF.RoleId = 2;
            userEF.CorporationName = cUserDTO.CorporationName;
            userEF.PIB = cUserDTO.PIB;
            context.Users.Update(userEF);
            context.SaveChanges();
            return cUserDTO;
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

        private bool CorporationNameExist(string corporationName)
        {
            return context.CorporateUsers.Any(c =>c.CorporationName==corporationName);
        }

        private bool PIBExists(string pib)
        {
            return context.CorporateUsers.Any(c => c.PIB == pib);
        }
    }
}
