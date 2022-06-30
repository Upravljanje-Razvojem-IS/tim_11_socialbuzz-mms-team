using MessagingService.DTOs.ChatDTOs;
using MessagingService.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MessagingService.Repositories.impl
{
    public class ChatRepository : IChatRepository
    {
        private readonly DataContext context;
        private readonly IUserRepository userRepository;
        private readonly IMessageRepository messageRepository;

        public ChatRepository(DataContext context, IUserRepository userRepository, IMessageRepository messageRepository)
        {
            this.context = context;
            this.userRepository = userRepository;
            this.messageRepository = messageRepository;
        }

        public ChatCreateDTO CreateChat(ChatCreateDTO chat)
        {
            var chatEF = new Chat();
            if (!CheckUserExists(chat.FirstUserId, chat.SecondUserId))
                throw new System.Exception("Foregin key violation");
            chatEF.ChatName = chat.ChatName;
            chatEF.FirstUserId = chat.FirstUserId;
            chatEF.SecondUserId = chat.SecondUserId;

            context.Chats.Add(chatEF);
            context.SaveChanges();
            return chat;
        }

        public void DeleteChat(int id)
        {
            var chat = context.Chats.Find(id);
            if (chat == null)
                throw new System.Exception("Not found");
            context.Chats.Remove(chat);
            context.SaveChanges();
        }

        public List<ChatReadDTO> GetAll()
        {
            var chats = context.Chats.ToList();
            var chatsDTO = chats.Select(c => new ChatReadDTO
            {
                ChatName = c.ChatName,
                Id = c.Id,
                FirstUser = userRepository.GetById(c.FirstUserId),
                SecondUser = userRepository.GetById(c.SecondUserId),
                Messages = messageRepository.GetByChatId(c.Id).ToList()
            }).ToList();
            return chatsDTO;
        }

        public ChatReadDTO GetById(int id)
        {
            var chat = context.Chats.Find(id);
            if (chat == null)
                throw new System.Exception("Not found");
            var chatDTO = new ChatReadDTO();
            chatDTO.Id = chat.Id;
            chatDTO.ChatName = chat.ChatName;
            chatDTO.FirstUser = userRepository.GetById(chat.FirstUserId);
            chatDTO.SecondUser = userRepository.GetById(chat.SecondUserId);
            chatDTO.Messages = messageRepository.GetByChatId(chat.Id).ToList();
            return chatDTO;

        }

        public ChatCreateDTO UpdateChat(int id, ChatCreateDTO chat)
        {
            var chatEF = context.Chats.Find(id);
            if (chatEF == null)
                throw new System.Exception("Not found");
            if (!CheckUserExists(chat.FirstUserId, chat.SecondUserId))
                throw new System.Exception("Foreign key exception");

            chatEF.ChatName = chat.ChatName;
            chatEF.FirstUserId = chat.FirstUserId;
            chatEF.SecondUserId = chat.SecondUserId;
            

            context.Chats.Update(chatEF);
            context.SaveChanges();
            return chat;
        }

        private bool CheckUserExists(int rId, int sId)
        {
            bool r = context.Users.Any(u => u.Id == rId);
            bool s = context.Users.Any(u => u.Id == sId);
            if (r && s)
                return true;
            return false;
        }
    }
}
