using System.Collections.Generic;
using UserService.DTOs.RoleDTOs;

namespace UserService.Repositories
{
    public interface IRoleRepository
    {
        List<RoleReadDTO> GetAll();

        RoleReadDTO GetById(int id);

        RoleCreateDTO CreateRole(RoleCreateDTO role);
        RoleCreateDTO UpdateRole(int id, RoleCreateDTO role);
        void DeleteRole(int id);

        //Dodatne metode
        RoleReadDTO GetByRoleName(string roleName);

        


    }
}
