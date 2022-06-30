using MessagingService.DTOs.GroupMessageDTOs;
using System.Collections.Generic;

namespace MessagingService.Repositories
{
    public interface IGroupMessageRepository
    {
        List<GroupMessageReadDTO> GetAll();
        GroupMessageReadDTO GetById(int id);
        List<GroupMessageReadDTO> GetByChatId(int chatId);

        GroupMessageCreateDTO Create(GroupMessageCreateDTO gmDTO);
        GroupMessageCreateDTO Update(int id, GroupMessageCreateDTO gmDTO);
        void Delete(int id);
    }
}
