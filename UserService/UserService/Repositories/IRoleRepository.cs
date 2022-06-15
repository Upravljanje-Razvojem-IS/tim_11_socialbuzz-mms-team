using System.Collections.Generic;
using UserService.Entities;

namespace UserService.Repositories
{
    public interface IRoleRepository
    {
        List<Role> GetAll();

        Role GetById(int id);

        Role CreateRole(Role role);
        Role UpdateRole(Role role);
        void DeleteRole(int id);

        //Dodatne metode
        Role GetByRole(string roleName);

        List<User> GetAllUsersByRole(string roleName);


    }
}
