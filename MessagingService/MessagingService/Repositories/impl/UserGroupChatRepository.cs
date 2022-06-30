using MessagingService.DTOs.UserDTOs;
using MessagingService.DTOs.UserGroupChat;
using MessagingService.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MessagingService.Repositories.impl
{
    public class UserGroupChatRepository : IUserGroupChatRepository
    {
        private readonly DataContext context;
        private readonly IUserRepository userRep;

        public UserGroupChatRepository(DataContext context, IUserRepository userRep)
        {
            this.context = context;
            this.userRep = userRep;
        }

        public UserGroupChatCreate AddUserToGroup(UserGroupChatCreate ugcD)
        {
            if (ugcD.GroupChatId < 0 || ugcD.UserId < 0)
                throw new System.Exception("Error");
            if(!CheckIfUserAndGroupExists(ugcD.UserId, ugcD.GroupChatId))
                throw new System.Exception("User or group chat not found");
            var ugc = new UserGroupChat();
            var ugcDTO = new UserGroupChatCreate();
            ugc.UserId = ugcDTO.UserId;
            ugc.GroupChatId = ugcDTO.GroupChatId;
            return ugcDTO;
        }

        public void DeleteUserFromGroupChat(UserGroupChatCreate ugcD)
        {
            var ugc = context.UserGroups.Where(c => c.UserId == ugcD.UserId && c.GroupChatId == ugcD.GroupChatId).FirstOrDefault();
            if(ugc == null)
                throw new System.Exception("Not found");
            context.UserGroups.Remove(ugc);
            context.SaveChanges();
        }

        public List<UserReadDTO> GetGroupUsers(int gcID)
        {
            var torke = context.UserGroups.Where(t => t.GroupChatId == gcID).ToList();            
            int count = torke.Count();
            var users = new List<UserReadDTO>();
            for (int i = 0; i < count; i++)
            {
                users.Add(userRep.GetById(torke[i].UserId));
            }
            return users;
        }

        public List<UserReadDTO> GetUsersByGroupChat(int uId,int gcID)
        {
            var torke = context.UserGroups.Where(t => t.GroupChatId == gcID).ToList();
            torke.Remove( torke.Find(s => s.UserId == uId));
            int count = torke.Count();
            var users = new List<UserReadDTO>();
            for(int i = 0; i < count; i++)
            {
                users.Add(userRep.GetById(torke[i].UserId));
            }
            return users;
        }

        public bool CheckIfUserAndGroupExists(int uId, int gId)
        {
            bool u = context.Users.Any(u => u.Id == uId);
            bool g = context.GroupChats.Any(g => g.Id == gId);
            if(u && g)
                return true;
            return false;
        }
    }
}
