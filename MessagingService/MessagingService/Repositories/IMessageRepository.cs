using MessagingService.DTOs.MessageDTOs;
using System.Collections.Generic;

namespace MessagingService.Repositories
{
    public interface IMessageRepository
    {
        List<MessageReadDTO> GetAll();
        MessageReadDTO GetById(int id);
        MessageCreateDTO Create(MessageCreateDTO messageDTO);
        MessageCreateDTO Update(int id, MessageCreateDTO messageDTO);
        void Delete(int id);

        /*Dodatne metode, get by chatId, user, */

        List<MessageReadDTO> GetByChatId(int chatId);
    }
}
