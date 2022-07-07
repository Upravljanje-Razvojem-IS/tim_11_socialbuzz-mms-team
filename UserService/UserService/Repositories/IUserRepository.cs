using System.Collections.Generic;
using UserService.DTOs.UserDTOs;

namespace UserService.Repositories
{
    public interface IUserRepository
    {
        List<UserReadDTO> GetAllUsers();
        UserReadDTO GetById(int id);
        UserCreateDTO CreateAdmin(UserCreateDTO userCreateDTO);
        UserCreateDTO UpdateAdmin(int id, UserCreateDTO userCreateDTO);
        void DeleteAdmin(int id);

        //Dodatne metode
        UserReadDTO GetByUsername(string username);
        UserReadDTO GetByContact(string contact);
        UserReadDTO GetByEmail(string email);
        List<UserReadDTO> GetUsersByActive(bool isActive);
        List<UserReadDTO> GetUsersByRole(string role);
    }
}
