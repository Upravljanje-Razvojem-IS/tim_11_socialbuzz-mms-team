using MessagingService.DTOs.MessageDTOs;
using MessagingService.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MessagingService.Repositories.impl
{
    public class MessageRepository : IMessageRepository
    {
        private readonly DataContext context;
        private readonly IUserRepository userRepository;

        public MessageRepository(DataContext context, IUserRepository userRepository)
        {
            this.context = context;
            this.userRepository = userRepository;
        }

        public MessageCreateDTO Create(MessageCreateDTO messageDTO)
        {
            var messageEF = new Message();
            if (!CheckChatExists(messageDTO.ChatId) || !CheckUserExists(messageDTO.RecieverId, messageDTO.SenderId))
                throw new System.Exception("Foregin key violation");
            messageEF.ChatId = messageDTO.ChatId;
            messageEF.SenderId = messageDTO.SenderId;
            messageEF.RecieverId = messageDTO.RecieverId;
            messageEF.Text = messageDTO.Text;
            messageEF.Date = System.DateTime.Now;

            context.Messages.Add(messageEF);
            context.SaveChanges();
            return messageDTO;
        }

        public void Delete(int id)
        {
            var message = context.Messages.Find(id);
            if (message == null)
                throw new System.Exception("Not found");
            context.Messages.Remove(message);
            context.SaveChanges();
        }

        public List<MessageReadDTO> GetAll()
        {
            var messages = context.Messages.ToList();
            if (messages.Count == 0)
                throw new System.Exception("Database empty");
            var messagesDTO = messages.Select(m => new MessageReadDTO
            {
                Id = m.Id,
                Date = m.Date,
                Text = m.Text,
                Sender = userRepository.GetById(m.SenderId),
                Reciever = userRepository.GetById(m.RecieverId),
                ChatName = context.Chats.Find(m.ChatId).ChatName

            }).ToList();
            return messagesDTO;
        }

        public MessageReadDTO GetById(int id)
        {
            var message = context.Messages.Find(id);
            if (message == null)
                throw new System.Exception("Message not found");
            var messageDTO = new MessageReadDTO();
            messageDTO.Id = message.Id;
            messageDTO.Date = message.Date;
            messageDTO.Text = message.Text;
            messageDTO.Sender = userRepository.GetById(message.SenderId);
            messageDTO.Reciever = userRepository.GetById(message.RecieverId);
            messageDTO.ChatName = context.Chats.Find(message.ChatId).ChatName;

            return messageDTO;
        }

        public MessageCreateDTO Update(int id, MessageCreateDTO messageDTO)
        {
            var messageEF = context.Messages.Find(id);
            if (messageEF == null)
                throw new System.Exception("Not found");
            if (!CheckChatExists(messageDTO.ChatId) || !CheckUserExists(messageDTO.RecieverId, messageDTO.SenderId))
                throw new System.Exception("Foreign key exception");

            messageEF.ChatId = messageDTO.ChatId;
            messageEF.SenderId = messageDTO.SenderId;
            messageEF.RecieverId = messageDTO.RecieverId;
            messageEF.Text = messageDTO.Text;
            messageEF.Date = System.DateTime.Now;

            context.Messages.Update(messageEF);
            context.SaveChanges();
            return messageDTO;
        }

        private bool CheckUserExists(int rId, int sId)
        {
            bool r = context.Users.Any(u => u.Id == rId);
            bool s = context.Users.Any(u => u.Id == sId);
            if(r && s)
                return true;
            return false;
        }
        private bool CheckChatExists(int id)
        {
            return context.Chats.Any(u => u.Id == id);
        }

        public List<MessageReadDTO> GetByChatId(int chatId)
        {
            var messages = context.Messages.Where(m => m.ChatId == chatId).ToList();
            /*if (messages.Count == 0)
                throw new System.Exception("Database empty");*/
            var messagesDTO = messages.Select(m => new MessageReadDTO
            {
                Id = m.Id,
                Date = m.Date,
                Text = m.Text,
                Sender = userRepository.GetById(m.SenderId),
                Reciever = userRepository.GetById(m.RecieverId),
                ChatName = context.Chats.Find(m.ChatId).ChatName

            }).ToList();
            return messagesDTO;
        }
    }
}
