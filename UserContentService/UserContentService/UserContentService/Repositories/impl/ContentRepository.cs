using System.Collections.Generic;
using System.Linq;
using UserContentService.DTOs.ContentDTOs;
using UserContentService.Entities;

namespace UserContentService.Repositories.impl
{
    public class ContentRepository : IContentRepository
    {
        private readonly DataContext context;
        private readonly IUserRepository userRep;

        public ContentRepository(DataContext context, IUserRepository userRep)
        {
            this.context = context;
            this.userRep = userRep;
        }

        public ContentReadDTO Create(ContentCreateDTO contentCreate)
        {
            var content = new Content();
            if (!CheckIfUserExists(contentCreate.UserId))
                throw new System.Exception("user doesnt exists, foreign key violation");
            content.UserId = contentCreate.UserId;
            content.Text = contentCreate.Text;
            content.Title = contentCreate.Title;
            content.Date = System.DateTime.Now;
            context.Contents.Add(content);
            context.SaveChanges();

            var cDTO = new ContentReadDTO();
            cDTO.Id = content.Id;
            cDTO.Title = content.Title;
            cDTO.Text = content.Text;
            cDTO.Date = content.Date;
            cDTO.User = userRep.GetById(content.UserId);
            return cDTO;
        }

        public void Delete(int id)
        {
            var content = context.Contents.Find(id);
            if (content == null)
                throw new System.Exception("Not found");
            context.Contents.Remove(content);
            context.SaveChanges();
        }

        public List<ContentReadDTO> GetAll()
        {
            var contents = context.Contents.ToList();
            if (contents.Count == 0)
                throw new System.Exception("Database is empty");
            var cDTO = contents.Select(ct => new ContentReadDTO
            {
                Id = ct.Id,
                Date = ct.Date,
                Title = ct.Title,
                Text = ct.Text,
                User = userRep.GetById(ct.Id)
            }).ToList();
            return cDTO;
        }

        public List<ContentReadDTO> GetAllContentsByUser(string username)
        {
            var user = userRep.FindByUsername(username);
            if (user == null)
                throw new System.Exception("user doesnt exists");
            var contents = context.Contents.Where(c => c.UserId == user.Id).ToList();
            if (contents.Count == 0)
                throw new System.Exception("Empty");
            var cDTO = contents.Select(ct => new ContentReadDTO
            {
                Id = ct.Id,
                Date = ct.Date,
                Title = ct.Title,
                Text = ct.Text,
                User = userRep.GetById(ct.UserId)
            }).ToList();
            return cDTO;
        }

        public ContentReadDTO GetById(int id)
        {
            var content = context.Contents.Find(id);
            if (content == null)
                throw new System.NotImplementedException();
            var cDTO = new ContentReadDTO();
            cDTO.Id = content.Id;
            cDTO.Title = content.Title;
            cDTO.Text = content.Text;
            cDTO.Date = content.Date;
            cDTO.User = userRep.GetById(content.UserId);
            return cDTO;
        }

        public List<ContentReadDTO> GetByText(string text)
        {
            var contents = context.Contents.Where(c => c.Text == text).ToList();
            if (contents.Count() == 0)
                throw new System.NotImplementedException();
            var cDTO = contents.Select(ct => new ContentReadDTO
            {
                Id = ct.Id,
                Date = ct.Date,
                Title = ct.Title,
                Text = ct.Text,
                User = userRep.GetById(ct.Id)
            }).ToList();
            return cDTO;
        }

        public List<ContentReadDTO> GetByTitle(string title)
        {
            var contents = context.Contents.Where(c => c.Title == title).ToList();
            if (contents.Count() == 0)
                throw new System.NotImplementedException();
            var cDTO = contents.Select(ct => new ContentReadDTO
            {
                Id = ct.Id,
                Date = ct.Date,
                Title = ct.Title,
                Text = ct.Text,
                User = userRep.GetById(ct.Id)
            }).ToList();
            return cDTO;
        }

        public List<ContentReadDTO> GetByUserId(int userId)
        {
            if (!CheckIfUserExists(userId))
                throw new System.Exception("user doesnt exists");
            var ct = context.Contents.Where(c => c.UserId == userId).ToList();
            if (ct.Count == 0)
                throw new System.Exception("Empty");
            var ctDTO = ct.Select(c => new ContentReadDTO
            {
                Id = c.Id,
                Date = c.Date,
                Title = c.Title,
                Text = c.Text,
                User = userRep.GetById(c.UserId)
            }).ToList();
            return ctDTO;
        }

        public ContentReadDTO Update(int id, ContentCreateDTO contentCreate)
        {
            var content = context.Contents.Find(id);
            if (content == null)
                throw new System.Exception("Not found");
            if (!CheckIfUserExists(contentCreate.UserId))
                throw new System.Exception("User not found. Foreign key violation");
            content.Title = contentCreate.Title;
            content.Text = contentCreate.Text;
            content.Date = System.DateTime.Now;
            content.UserId = contentCreate.UserId;

            context.Contents.Update(content);
            context.SaveChanges();

            var cDTO = new ContentReadDTO();
            cDTO.Id = content.Id;
            cDTO.Title = content.Title;
            cDTO.Text = content.Text;
            cDTO.Date = content.Date;
            cDTO.User = userRep.GetById(content.UserId);
            return cDTO;
        }

        private bool CheckIfUserExists(int id)
        {
            return context.Users.Any(u => u.Id == id);
        }
    }
}
