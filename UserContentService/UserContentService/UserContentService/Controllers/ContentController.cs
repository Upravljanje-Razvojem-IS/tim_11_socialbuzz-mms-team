using Microsoft.AspNetCore.Mvc;
using UserContentService.DTOs.ContentDTOs;
using UserContentService.Repositories;

namespace UserContentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly IContentRepository repository;

        public ContentController(IContentRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var contents = repository.GetAll();
            if (contents.Count == 0)
                return NotFound();
            return Ok(contents);
        }

        [HttpGet]
        [Route("GetByContentId/{id}")]
        public ActionResult GetById(int id)
        {
            var ct = repository.GetById(id);
            if (ct == null)
                return NotFound();
            return Ok(ct);
        }

        [HttpGet]
        [Route("GetContentsByUser/{username}")]
        public ActionResult GetContentsByUser(string username)
        {
            var ct = repository.GetAllContentsByUser(username);
            if (ct.Count == 0)
                return NotFound();
            return Ok(ct);
        }

        [HttpPost]
        public ActionResult CreateAd(ContentCreateDTO ctDTO)
        {
            if (ctDTO == null)
                return BadRequest();
            var c = repository.Create(ctDTO);
            return Ok(c);
        }

        [HttpPut]
        public ActionResult UpdateContent(int id, ContentCreateDTO ctDTO)
        {
            if (id == null || ctDTO == null)
                return BadRequest();
            var ct = repository.GetById(id);
            if (ct == null)
                return NotFound();
            repository.Update(id, ctDTO);
            return Ok(ctDTO);
        }

        [HttpDelete]
        public ActionResult DeleteContent(int id)
        {
            if (id == null)
                return BadRequest();
            var ct = repository.GetById(id);
            if (ct == null)
                return NotFound();
            repository.Delete(id);
            return Ok(new { message = "Content deleted" });
        }

        [HttpGet]
        [Route("GetByTitle/{title}")]
        public ActionResult GetByTitle(string title)
        {
            var ct = repository.GetByTitle(title);
            if (ct == null)
                return NotFound();
            return Ok(ct);
        }

        [HttpGet]
        [Route("GetByText/{text}")]
        public ActionResult GetByText(string text)
        {
            var ct = repository.GetByText(text);
            if (ct == null)
                return NotFound();
            return Ok(ct);
        }
    }
}
