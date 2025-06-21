using GradProj.Application.DTO;
using GradProj.Application.ServiceAbs;
using GradProj.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GradProj.API.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class NoteController : ControllerBase
    {
        protected readonly INoteService _noteService;
        public NoteController(INoteService eventService)
        {
            _noteService = eventService;

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var events = await _noteService.GetAllAsync();
            return Ok(events);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var event1 = await _noteService.GetByIdAsync(id);
            if (event1 == null) return NotFound();
            return Ok(event1);
        }
        [HttpPut]
        public IActionResult Update(Note note)
        {
            _noteService.UpdateAsync(note);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _noteService.DeleteAsync(id);
            return NoContent();
        }
        [Authorize]
        [HttpPut]
        public IActionResult CreateNote( [FromBody]NoteDto dto)
        {
            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var convertnote = new Note
            {
                UserId = userId,
                Title = dto.Title,
                Details = dto.Details,



            };
            _noteService.AddAsync(convertnote);
            return Ok(convertnote);


        }
        [Authorize]
        [HttpPost]
        public IActionResult GetUserNotes()
        {
            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var notes = _noteService.GetUserNotes(userId);
            if (notes == null) return NotFound();
            return Ok(notes);
        }
    }
}
