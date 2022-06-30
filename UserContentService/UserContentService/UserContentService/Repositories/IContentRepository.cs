using System.Collections.Generic;
using UserContentService.DTOs.ContentDTOs;
using UserContentService.Entities;

namespace UserContentService.Repositories
{
    public interface IContentRepository
    {
        List<ContentReadDTO> GetAll();
        ContentReadDTO GetById(int id);
        ContentReadDTO Create(ContentCreateDTO contentCreate);
        ContentReadDTO Update(int id, ContentCreateDTO contentCreate);
        void Delete(int id);
        List<ContentReadDTO> GetAllContentsByUser(string username);
        List<ContentReadDTO> GetByTitle(string title);
        List<ContentReadDTO> GetByText(string text);

        List<ContentReadDTO> GetByUserId(int userId);
    }
}
