using Microsoft.AspNetCore.Mvc;
using UserContentService.DTOs.AdDTOs;
using UserContentService.Repositories;

namespace UserContentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdController : ControllerBase
    {
        private readonly IAdRepository repository;

        public AdController(IAdRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var ads = repository.GetAll();
            if(ads.Count == 0)
                return NotFound();
            return Ok(ads);
        }

        [HttpGet]
        [Route("GetByAdId/{id}")]
        public ActionResult GetById(int id)
        {
            var ad = repository.GetById(id);
            if (ad == null)
                return NotFound();
            return Ok(ad);
        }

        [HttpGet]
        [Route("GetAdsByUser/{username}")]
        public ActionResult GetAdsByUser(string username)
        {
            var ads = repository.GetAllAdsByUser(username);
            if (ads.Count == 0)
                return NotFound();
            return Ok(ads);
        }

        [HttpPost]
        public ActionResult CreateAd(AdCreateDTO adDTO)
        {
            if (adDTO == null)
                return BadRequest();
            repository.Create(adDTO);
            return Ok(adDTO);
        }

        [HttpPut]
        public ActionResult UpdateAd(int id, AdCreateDTO adDTO)
        {
            if (id == null || adDTO == null)
                return BadRequest();
            var ad = repository.GetById(id);
            if (ad == null)
                return NotFound();
            repository.Update(id, adDTO);
            return Ok(adDTO);
        }

        [HttpDelete]
        public ActionResult DeleteAd(int id)
        {
            if (id == null)
                return BadRequest();
            var ad = repository.GetById(id);
            if (ad == null)
                return NotFound();
            repository.Delete(id);
            return Ok(new { message = "Ad deleted" });
        }

        [HttpGet]
        [Route("GetByTitle/{title}")]
        public ActionResult GetByTitle(string title)
        {
            var ad = repository.GetByTitle(title);
            if (ad == null)
                return NotFound();
            return Ok(ad);
        }

        [HttpGet]
        [Route("GetByText/{text}")]
        public ActionResult GetByText(string text)
        {
            var ad = repository.GetByText(text);
            if (ad == null)
                return NotFound();
            return Ok(ad);
        }

    }
}
