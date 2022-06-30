using System.Collections.Generic;
using UserContentService.DTOs.AdDTOs;

namespace UserContentService.Repositories
{
    public interface IAdRepository
    {
        List<AdReadDTO> GetAll();
        AdReadDTO GetById(int id);
        AdReadDTO Create(AdCreateDTO adCreate);
        AdReadDTO Update(int id,AdCreateDTO adCreate);
        void Delete(int id);
        List<AdReadDTO> GetAllAdsByUser(string username);
        List<AdReadDTO> GetByTitle(string title);
        List<AdReadDTO> GetByText(string text);

        List<AdReadDTO> GetByUserId(int userId);


    }
}
