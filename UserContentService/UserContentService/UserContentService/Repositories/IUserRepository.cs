using System.Collections.Generic;
using UserContentService.DTOs;
using UserContentService.DTOs.UserDTOs;

namespace UserContentService.Repositories
{
    public interface IUserRepository
    {
        public List<UserReadDTO> GetAll();
        public UserReadDTO GetById(int id);
        UserCreateDTO Create(UserCreateDTO user);
        UserCreateDTO Update(int id,UserCreateDTO user);
        void Delete(int id);

        public UserReadDTO FindByUsername(string username);
    }
}
