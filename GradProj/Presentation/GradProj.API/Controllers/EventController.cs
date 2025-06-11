using GradProj.Application.ServiceAbs;
using GradProj.Application.ServiceImp;
using GradProj.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GradProj.Application.DTO;

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
        public IActionResult GetById(Guid id)
        {
            var event1 = _eventService.GetByIdAsync(id);
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
        [HttpPut]
        public IActionResult CreateEvent(EventDto dto) {
            var ALLAHBELANIVERSIN = new Event
            {
                UserId = dto.UserId,
                Title = dto.Title,
                Description = dto.Description,
                EventDate = dto.EventDate,
            };
            _eventService.AddAsync(ALLAHBELANIVERSIN);
            return Ok(ALLAHBELANIVERSIN);
           

       }

    }
}
