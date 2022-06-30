using System.Collections.Generic;
using System.Linq;
using UserContentService.DTOs;
using UserContentService.DTOs.UserDTOs;
using UserContentService.Entities;

namespace UserContentService.Repositories.impl
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext context;
        /*private readonly IAdRepository adRepository;
        private readonly IContentRepository contentRepository;*/

        public UserRepository(DataContext context/*, IAdRepository adRepository, IContentRepository contentRepository*/)
        {
            this.context = context;
            /*this.adRepository = adRepository;
            this.contentRepository = contentRepository;*/
        }

        public UserCreateDTO Create(UserCreateDTO user)
        {
            var userEF = new User();
            userEF.Username = user.Username;
            context.Users.Add(userEF);
            context.SaveChanges();
            return user;
        }

        public void Delete(int id)
        {
            var user = context.Users.Find(id);
            if (user == null)
                throw new System.Exception("Not found");
            context.Users.Remove(user);
            context.SaveChanges();
        }

        public List<UserReadDTO> GetAll()
        {
            var users = context.Users.ToList();
            if (users.Count() == 0)
                throw new System.Exception("No users");
            var usersDTO = users.Select(users => new UserReadDTO
            {
                Id = users.Id,
                Username = users.Username,
            }).ToList();
            return usersDTO;
        }

        /*public UserReadALL GetAllAdsAndContentsByUser(string username)
        {
            var user = context.Users.Where(user => user.Username == username).FirstOrDefault();
            if (user == null)
                throw new System.Exception("Not found");
            var userDTO = new UserReadALL();
            userDTO.Id = user.Id;
            userDTO.Username = username;
            userDTO.Ads = adRepository.GetByUserId(user.Id).ToList();
            userDTO.Contents = contentRepository.GetByUserId(user.Id).ToList();

            return userDTO;
        }*/

        public UserReadDTO GetById(int id)
        {
            var user = context.Users.Find(id);
            if (user == null)
                throw new System.Exception("Not found");
            var userDTO = new UserReadDTO();
            userDTO.Id = user.Id;
            userDTO.Username = user.Username;
            return userDTO;
        }

        public UserCreateDTO Update(int id,UserCreateDTO user)
        {
            var userEF = context.Users.Find(id);
            if (userEF == null)
                throw new System.Exception("Not found");
            userEF.Username = user.Username;
            context.Users.Update(userEF);
            context.SaveChanges();
            
            return user;
        }

        public UserReadDTO FindByUsername(string username)
        {
            var user = context.Users.First(u => u.Username == username);
            if (user == null)
                throw new System.Exception("Not found");
            var userDTO = new UserReadDTO();
            userDTO.Id = user.Id;
            userDTO.Username = user.Username;
            return userDTO;
        }
    }
}
