using System.Collections.Generic;
using System.Linq;
using UserService.Attributes;
using UserService.DTOs.RoleDTOs;
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

        public RoleCreateDTO CreateRole(RoleCreateDTO role)
        {
            var roleEF = new Role();
            string roleName = role.RoleName;
            if (string.IsNullOrEmpty(roleName))
                throw new AppException("Rolename can't be empty");
            if (RoleNameExists(roleName))
                throw new UniqueException(roleName + " already exists, role name must be unique");
            roleEF.RoleName = roleName;
            context.Roles.Add(roleEF);
            context.SaveChanges();
            return role;

        }

        public void DeleteRole(int id)
        {
            var role = context.Roles.Find(id);
            if (role == null)
                throw new AppException("Role doesn't exist");
            context.Roles.Remove(role);
            context.SaveChanges();
        }

        public List<RoleReadDTO> GetAll()
        {
            var roles = context.Roles.ToList();
            if (roles.Count() < 0)
                throw new AppException("No roles found in database");
            var rolesDTO = roles.Select(roles => new RoleReadDTO
            {
                RoleId = roles.RoleId,
                RoleName = roles.RoleName,
            }).ToList();

            return rolesDTO;
        }

        public RoleReadDTO GetById(int id)
        {
            var role = context.Roles.Find(id);
            if (role == null)
                throw new AppException("Role with id: " + id + " was not found");
            var roleDTO = new RoleReadDTO();
            roleDTO.RoleId = role.RoleId;
            roleDTO.RoleName = role.RoleName;
            return roleDTO;

        }

        public RoleReadDTO GetByRoleName(string roleName)
        {
            
            var role = context.Roles.FirstOrDefault(r => r.RoleName == roleName);
            if (role == null)
                throw new AppException("Role with name: " + roleName + " was not found");
            var roleDTO = new RoleReadDTO();
            roleDTO.RoleId = role.RoleId;
            roleDTO.RoleName= role.RoleName;
            return roleDTO;
        }

        public RoleCreateDTO UpdateRole(int id, RoleCreateDTO role)
        {
            var roleEF = context.Roles.Find(id);
            if (roleEF == null)
                throw new Attributes.KeyNotFoundException("Role with id: " + id + " was not found");
            string roleName = role.RoleName;
            if (string.IsNullOrEmpty(roleName))
                throw new AppException("Rolename cannot be empty string");
            if (RoleNameExists(roleName))
                throw new UniqueException("Role with name:" + roleName + " already exists, role name must be unique");
            roleEF.RoleName = roleName;
            context.Roles.Update(roleEF);
            context.SaveChanges();
            return role;


        }        

        private bool RoleNameExists(string roleName)
        {
            return context.Roles.Any(e => e.RoleName == roleName);
        }
    }
}
