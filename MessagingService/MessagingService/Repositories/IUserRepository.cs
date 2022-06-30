using MessagingService.DTOs.UserDTOs;
using System.Collections.Generic;

namespace MessagingService.Repositories
{
    public interface IUserRepository
    {
        List<UserReadDTO> GetAll();
        UserReadDTO GetById(int id);

        UserCreateDTO CreateUser(UserCreateDTO userDTO);
        UserReadDTO UpdateUser(int id,UserCreateDTO userDTO);
        void DeleteUser(int id);

        List<UserReadDTO> GetUsersFromGroupChat(int id);
    }
}
