using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using UserService.Entities;

namespace UserService.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext context;

        public UserRepository(DataContext context)
        {
            this.context = context;
        }

        public User Create(User user)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<User> GetAll()
        {
            var users = context.Users.ToList();
            return users;
        }

        public User GetById(int id)
        {
            var user = context.Users.Find(id);

            return user;
        }

        public User GetByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public User GetByUsername(string username)
        {
            var user = context.Users.FirstOrDefault(x => x.Username == username);
            return user;
        }

        public User Update(int id, User user)
        {
            throw new System.NotImplementedException();
        }

        public List<User> GetByActive(bool isActive)
        {
            var users = context.Users.Where(user => user.isActive == isActive).ToList();
            return users;
        }

        
    }
}
