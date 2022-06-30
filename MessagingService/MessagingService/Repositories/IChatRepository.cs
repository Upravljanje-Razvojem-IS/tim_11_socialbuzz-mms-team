using MessagingService.DTOs.ChatDTOs;
using System.Collections.Generic;

namespace MessagingService.Repositories
{
    public interface IChatRepository
    {
        List<ChatReadDTO> GetAll();
        ChatReadDTO GetById(int id);
        ChatCreateDTO CreateChat(ChatCreateDTO chat);
        ChatCreateDTO UpdateChat(int id, ChatCreateDTO chat);
        void DeleteChat(int id);

        //Get chat by user
        
    }
}
