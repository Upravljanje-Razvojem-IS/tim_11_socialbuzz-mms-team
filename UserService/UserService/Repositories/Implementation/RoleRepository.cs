using System.Collections.Generic;
using System.Linq;
using UserService.Entities;

namespace UserService.Repositories.Implementation
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DataContext context;

        public RoleRepository(DataContext context)
        {
            this.context = context;
        }

        //metode
        public Role CreateRole(Role role)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteRole(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Role> GetAll()
        {
            var roleList = context.Roles.ToList();

            return roleList;
        }

        public List<User> GetAllUsersByRole(string roleName)
        {
            throw new System.NotImplementedException();
        }

        public Role GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Role GetByRole(string roleName)
        {
            throw new System.NotImplementedException();
        }

        public Role UpdateRole(Role role)
        {
            throw new System.NotImplementedException();
        }
    }
}
