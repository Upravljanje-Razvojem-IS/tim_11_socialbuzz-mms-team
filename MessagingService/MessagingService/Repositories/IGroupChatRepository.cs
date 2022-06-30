using MessagingService.DTOs.GroupChatDTOs;
using System.Collections.Generic;

namespace MessagingService.Repositories
{
    public interface IGroupChatRepository
    {
        List<GroupChatReadDTO> GetAll();
        GroupChatReadDTO GetById(int id);

        GroupChatCreateDTO Create(GroupChatCreateDTO gcDTO);
        GroupChatCreateDTO Update(int id,GroupChatCreateDTO gcDTO);
        void Delete(int id);
    }
}
