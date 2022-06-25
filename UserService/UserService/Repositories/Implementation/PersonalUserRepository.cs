using System.Collections.Generic;
using System.Linq;
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
            throw new System.NotImplementedException();
        }

        public void DeletePersonalUser(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<PersonalUserReadDTO> GetAllPersonalUsers()
        {
            var pUsers = context.PersonalUsers.ToList();
            
        }

        public PersonalUserReadDTO GetPersonalUserById(int id)
        {
            throw new System.NotImplementedException();
        }

        public PersonalUserCreateDTO UpdatePersonalUser(int id, PersonalUserCreateDTO personalUser)
        {
            throw new System.NotImplementedException();
        }
    }
}
