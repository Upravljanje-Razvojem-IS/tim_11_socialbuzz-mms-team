using MessagingService.DTOs.GroupChatDTOs;
using MessagingService.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MessagingService.Repositories.impl
{
    public class GroupChatReposotiry : IGroupChatRepository
    {
        private readonly DataContext context;
        private readonly IUserGroupChatRepository ugcRep;
        private readonly IGroupMessageRepository gmRep;

        public GroupChatReposotiry(DataContext context, IUserGroupChatRepository ugcRep, IGroupMessageRepository gmRep)
        {
            this.context = context;
            this.ugcRep = ugcRep;
            this.gmRep = gmRep;
        }

        public GroupChatCreateDTO Create(GroupChatCreateDTO gcDTO)
        {
            var gc = new GroupChat();
            if (gcDTO == null)
                throw new System.Exception("Error");
            gc.Name = gcDTO.Name;
            context.GroupChats.Add(gc);
            context.SaveChanges();
            return gcDTO;
        }

        public void Delete(int id)
        {
            var gc = context.GroupChats.Find(id);
            if (gc == null)
                throw new System.Exception("Not found");
            context.GroupChats.Remove(gc);
            context.SaveChanges();
        }

        public List<GroupChatReadDTO> GetAll()
        {
            var chats = context.GroupChats.ToList();
            if (chats.Count < 0)
                throw new System.Exception("Database empty");
            var cDTO = chats.Select(c => new GroupChatReadDTO
            {
                Id = c.Id,
                Name = c.Name,
                Users =ugcRep.GetGroupUsers(c.Id),
                GroupMessages = gmRep.GetByChatId(c.Id),

            }).ToList();
            return cDTO;
        }

        public GroupChatReadDTO GetById(int id)
        {
            var gc = context.GroupChats.Find(id);
            if (gc == null)
                throw new System.Exception("Not found");
            var gcDTO = new GroupChatReadDTO();
            gcDTO.Id = gc.Id;
            gcDTO.Name = gc.Name;
            gcDTO.Users = ugcRep.GetGroupUsers(gc.Id);
            gcDTO.GroupMessages = gmRep.GetByChatId(gc.Id);
            return gcDTO;
        }

        public GroupChatCreateDTO Update(int id, GroupChatCreateDTO gcDTO)
        {
            var gc = context.GroupChats.Find(id);
            if (gc == null)
                throw new System.Exception("Not found");
            if (gcDTO == null)
                throw new System.Exception("Error");
            gc.Name = gcDTO.Name;
            context.GroupChats.Update(gc);
            context.SaveChanges();
            return gcDTO;
        }

        
    }
}
