using System.Collections.Generic;
using UserService.DTOs.CorporateUserDTO;

namespace UserService.Repositories.Implementation
{
    public interface ICorporateUserRepository
    {
        List<CorporateUserReadDTO> GetAllCorporateUsers();
        CorporateUserReadDTO GetCorporateUserById(int id);
        CorporateUserCreateDTO CreateCorporateUser(CorporateUserCreateDTO cUserDTO);
        CorporateUserCreateDTO UpdateCorporatelUser(int id, CorporateUserCreateDTO cUserDTO);
        void DeleteCorporateUser(int id);


        CorporateUserReadDTO GetByUsername(string username);
        CorporateUserReadDTO GetByContact(string contact);
        CorporateUserReadDTO GetByEmail(string email);
        CorporateUserReadDTO GetByPIB(string PIB);
        CorporateUserReadDTO GetByCorporationName(string corporationName);
        List<CorporateUserReadDTO> GetCorporateUsersByActive(bool isActive);
    }
}
