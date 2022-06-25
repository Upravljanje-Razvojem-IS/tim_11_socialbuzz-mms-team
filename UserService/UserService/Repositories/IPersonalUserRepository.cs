using System.Collections.Generic;
using UserService.DTOs.PersonalUserDTO;

namespace UserService.Repositories
{
    public interface IPersonalUserRepository
    {
        List<PersonalUserReadDTO> GetAllPersonalUsers();
        PersonalUserReadDTO GetPersonalUserById(int id);
        PersonalUserCreateDTO CreatePersonalUser(PersonalUserCreateDTO personalUser);
        PersonalUserCreateDTO UpdatePersonalUser(int id, PersonalUserCreateDTO personalUser);
        void DeletePersonalUser(int id);


        PersonalUserReadDTO GetByUsername(string username);
        PersonalUserReadDTO GetByContact(string contact);
        PersonalUserReadDTO GetByEmail(string email);
        List<PersonalUserReadDTO> GetPersonalUsersByActive(bool isActive);
        List<PersonalUserReadDTO> GetPersonalUsersByFirstName(string firstName);
        List<PersonalUserReadDTO> GetPersonalUsersByLastName(string lastName);


    }
}
