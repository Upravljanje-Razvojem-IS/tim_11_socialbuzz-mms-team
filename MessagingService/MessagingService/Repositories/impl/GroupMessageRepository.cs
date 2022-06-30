using MessagingService.DTOs.GroupMessageDTOs;
using MessagingService.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MessagingService.Repositories.impl
{
    public class GroupMessageRepository : IGroupMessageRepository
    {
        private readonly DataContext context;
        private readonly IUserRepository userRep;
        private readonly IUserGroupChatRepository ugcRep;

        public GroupMessageRepository(DataContext context, IUserRepository userRep, IUserGroupChatRepository ugcRep)
        {
            this.context = context;
            this.userRep = userRep;
            this.ugcRep = ugcRep;
        }
        public List<GroupMessageReadDTO> GetAll()
        {
            var gm = context.GroupMessages.ToList();
            if (gm.Count < 0)
                throw new System.Exception("Database empty");
            var gmDTO = gm.Select(x => new GroupMessageReadDTO
            {
                Id = x.Id,
                Date = x.Date,
                Text = x.Text,
                Sender = userRep.GetById(x.SenderId),
                Recievers = ugcRep.GetUsersByGroupChat(x.SenderId,x.GroupChatId),
                GroupChatName = context.GroupChats.Find(x.GroupChatId).Name
            }).ToList();

            return gmDTO;
        }

        public GroupMessageReadDTO GetById(int id)
        {
            var gm = context.GroupMessages.Find(id);
            if (gm == null)
                throw new System.Exception("Not found");
            var gmDTO = new GroupMessageReadDTO();
            gmDTO.Id = gm.Id;
            gmDTO.Date = gm.Date;
            gmDTO.Text = gm.Text;
            gmDTO.Sender = userRep.GetById(gm.SenderId);
            gmDTO.Recievers = ugcRep.GetUsersByGroupChat(gm.SenderId, gm.GroupChatId);
            gmDTO.GroupChatName = context.GroupChats.Find(gm.GroupChatId).Name;

            return gmDTO;
        }

        public List<GroupMessageReadDTO> GetByChatId(int chatId)
        {
            var gm = context.GroupMessages.Where(m => m.GroupChatId == chatId).ToList(); ;
            if (gm.Count < 0)
                throw new System.Exception("Database empty");
            var gmDTO = gm.Select(x => new GroupMessageReadDTO
            {
                Id = x.Id,
                Date = x.Date,
                Text = x.Text,
                Sender = userRep.GetById(x.SenderId),
                Recievers = ugcRep.GetUsersByGroupChat(x.SenderId, x.GroupChatId),
                GroupChatName = context.GroupChats.Find(x.GroupChatId).Name
            }).ToList();

            return gmDTO;
        }

        public GroupMessageCreateDTO Create(GroupMessageCreateDTO gmDTO)
        {
            var gmEf = new GroupMessage();
            if (!CheckIfSenderAndGroupExists(gmDTO.SenderId, gmDTO.GroupChatId))
                throw new System.Exception("User or group chat does not exits");
            gmEf.GroupChatId = gmDTO.GroupChatId;
            gmEf.SenderId = gmDTO.SenderId;
            gmEf.Text = gmDTO.Text;
            context.GroupMessages.Add(gmEf);
            context.SaveChanges();
            return gmDTO;
        }

        public GroupMessageCreateDTO Update(int id, GroupMessageCreateDTO gmDTO)
        {
            var gmEf = context.GroupMessages.Find(id);
            if (gmEf == null)
                throw new System.Exception("Not found");
            if (!CheckIfSenderAndGroupExists(gmDTO.SenderId, gmDTO.GroupChatId))
                throw new System.Exception("User or group chat does not exits");
            gmEf.GroupChatId = gmDTO.GroupChatId;
            gmEf.SenderId = gmDTO.SenderId;
            gmEf.Text = gmDTO.Text;
            context.GroupMessages.Update(gmEf);
            context.SaveChanges();
            return gmDTO;

        }

        public void Delete(int id)
        {
            var gm = context.GroupMessages.Find(id);
            if (gm == null)
                throw new System.Exception("Not found");
            context.GroupMessages.Remove(gm);
            context.SaveChanges();
        }

        private bool CheckIfSenderAndGroupExists(int sId, int gId)
        {
            bool s = context.Users.Any(s => s.Id == sId);
            bool g = context.GroupChats.Any(g => g.Id == gId);
            if(g && s)
                return true;
            return false;
        }
    }
}
