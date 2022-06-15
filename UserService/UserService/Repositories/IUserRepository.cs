using System.Collections.Generic;
using UserService.Entities;

namespace UserService.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetById(int id);       

        User Create(User user);
        User Update(int id, User user);

        void Delete(int id);

        //Dodatne metode

        User GetByEmail(string email);
        User GetByUsername(string username);
        List<User> GetByActive(bool isActive);

    }
}
