using System.Collections.Generic;
using System.Linq;
using UserContentService.DTOs.AdDTOs;
using UserContentService.Entities;

namespace UserContentService.Repositories.impl
{
    public class AdRepository : IAdRepository
    {
        private readonly DataContext context;
        private readonly IUserRepository userRep;

        public AdRepository(DataContext context, IUserRepository userRep)
        {
            this.context = context;
            this.userRep = userRep;
        }

        public AdReadDTO Create(AdCreateDTO adCreate)
        {
            var ad = new Ad();
            if (!CheckIfUserExists(adCreate.UserId))
                throw new System.Exception("user doesnt exists, foreign key violation");
            ad.UserId = adCreate.UserId;
            ad.Text = adCreate.Text;
            ad.Title = adCreate.Title;
            ad.Date = System.DateTime.Now;
            ad.PASId = adCreate.PASId;
            context.Ads.Add(ad);
            context.SaveChanges();

            var adDTO = new AdReadDTO();
            adDTO.Id = ad.Id;
            adDTO.Title = ad.Title;
            adDTO.Text = ad.Text;
            adDTO.Date = ad.Date;
            adDTO.User = userRep.GetById(ad.UserId);
            adDTO.PAS = PASMockConstants.pASMocks.FirstOrDefault(e => e.Id == ad.PASId);

            return adDTO;


        }

        public void Delete(int id)
        {
            var ad = context.Ads.Find(id);
            if (ad == null)
                throw new System.Exception("Not found");
            context.Ads.Remove(ad);
            context.SaveChanges();
        }

        public List<AdReadDTO> GetAll()
        {
            var ads = context.Ads.ToList();
            if (ads.Count == 0)
                throw new System.Exception("Database is empty");
            var adsDTO = ads.Select(ad => new AdReadDTO
            {
                Id = ad.Id,
                Date = ad.Date,
                Title = ad.Title,
                Text = ad.Text,
                User = userRep.GetById(ad.Id),
                PAS = PASMockConstants.pASMocks.FirstOrDefault(e => e.Id == ad.PASId)
            }).ToList();
            return adsDTO;
        }

        public List<AdReadDTO> GetAllAdsByUser(string username)
        {
            
            var user = userRep.FindByUsername(username);
            if (user == null)
                throw new System.Exception("user doesnt exists");
            var ads = context.Ads.Where(a => a.UserId == user.Id).ToList();
            if (ads.Count == 0)
                throw new System.Exception("Empty");
            var adsDTO = ads.Select(ad => new AdReadDTO
            {
                Id = ad.Id,
                Date = ad.Date,
                Title = ad.Title,
                Text = ad.Text,
                User = userRep.GetById(ad.UserId),
                PAS = PASMockConstants.pASMocks.FirstOrDefault(e => e.Id == ad.PASId)
            }).ToList();
            return adsDTO;

        }

        public AdReadDTO GetById(int id)
        {
            var ad = context.Ads.Find(id);
            if(ad == null)
                throw new System.NotImplementedException();
            var adDTO = new AdReadDTO();
            adDTO.Id = ad.Id;
            adDTO.Title = ad.Title;
            adDTO.Text = ad.Text;
            adDTO.Date = ad.Date;
            adDTO.User = userRep.GetById(ad.UserId);
            adDTO.PAS = PASMockConstants.pASMocks.FirstOrDefault(e => e.Id == ad.PASId);
            return adDTO;

        }

        public List<AdReadDTO> GetByText(string text)
        {
            var ads = context.Ads.Where(a => a.Text == text).ToList();
            if (ads.Count() == 0)
                throw new System.NotImplementedException();
            var adsDTO = ads.Select(ad => new AdReadDTO
            {
                Id = ad.Id,
                Date = ad.Date,
                Title = ad.Title,
                Text = ad.Text,
                User = userRep.GetById(ad.Id),
                PAS = PASMockConstants.pASMocks.FirstOrDefault(e => e.Id == ad.PASId)
            }).ToList();
            return adsDTO;
        }

        public List<AdReadDTO> GetByTitle(string title)
        {
            var ads = context.Ads.Where(a => a.Title == title).ToList();
            if (ads.Count() == 0)
                throw new System.NotImplementedException();
            var adsDTO = ads.Select(ad => new AdReadDTO
            {
                Id = ad.Id,
                Date = ad.Date,
                Title = ad.Title,
                Text = ad.Text,
                User = userRep.GetById(ad.Id),
                PAS = PASMockConstants.pASMocks.FirstOrDefault(e => e.Id == ad.PASId)
            }).ToList();
            return adsDTO;
        }

        public List<AdReadDTO> GetByUserId(int userId)
        {
            
            if (!CheckIfUserExists(userId))
                throw new System.Exception("user doesnt exists");
            var ads = context.Ads.Where(a => a.UserId == userId).ToList();
            if (ads.Count == 0)
                throw new System.Exception("Empty");
            var adsDTO = ads.Select(ad => new AdReadDTO
            {
                Id = ad.Id,
                Date = ad.Date,
                Title = ad.Title,
                Text = ad.Text,
                User = userRep.GetById(ad.UserId),
                PAS = PASMockConstants.pASMocks.FirstOrDefault(e => e.Id == ad.PASId)
            }).ToList();
            return adsDTO;
        }

        public AdReadDTO Update(int id, AdCreateDTO adCreate)
        {
            var ad = context.Ads.Find(id);
            if(ad == null)
                throw new System.Exception("Not found");
            if (!CheckIfUserExists(adCreate.UserId))
                throw new System.Exception("User not found. Foreign key violation");
            ad.Title = adCreate.Title;
            ad.Text = adCreate.Text;
            ad.Date = System.DateTime.Now;
            ad.UserId = adCreate.UserId;
            
            context.Ads.Update(ad);
            context.SaveChanges();

            var adDTO = new AdReadDTO();
            adDTO.Id = ad.Id;
            adDTO.Title = ad.Title;
            adDTO.Text = ad.Text;
            adDTO.Date = ad.Date;
            adDTO.User = userRep.GetById(ad.UserId);
            adDTO.PAS = PASMockConstants.pASMocks.FirstOrDefault(e => e.Id == ad.PASId);

            return adDTO;

        }

        private bool CheckIfUserExists(int id)
        {
            return context.Users.Any(u => u.Id == id);
        }
    }
}
