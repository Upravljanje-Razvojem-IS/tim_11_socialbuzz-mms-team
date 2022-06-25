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


    }
}
