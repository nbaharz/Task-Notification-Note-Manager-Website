using GradProj.Application.ServiceAbs;
using GradProj.Application.ServiceImp;
using GradProj.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GradProj.Application.DTO;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace GradProj.API.Controllers
{
    
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EventController : ControllerBase
    {
        protected readonly IEventService _eventService;
        public EventController(IEventService eventService)
        {
            _eventService = eventService;
            
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var events = await _eventService.GetAllAsync();
            return Ok(events);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var event1 = await _eventService.GetByIdAsync(id);
            if (event1 == null) return NotFound();
            return Ok(event1);
        }
        [HttpPut]
        public IActionResult Update(Event event1)
        {
            _eventService.UpdateAsync(event1);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _eventService.DeleteAsync(id);
            return NoContent();
        }
        [Authorize]
        [HttpPost]
        public IActionResult CreateEvent([FromBody] EventDto dto) {
            
           var id = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            _eventService.CreateEventAsync(dto, id);
            return Ok(dto);
           

       }
        [Authorize]
        [HttpPost]
        public IActionResult GetUserEvents()
        {
            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var tasks = _eventService.GetSpecifiedUserEvents(userId);
            if (tasks == null) return NotFound();
            return Ok(tasks);
        }

    }
}
