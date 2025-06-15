using GradProj.Application.ServiceAbs;
using Microsoft.AspNetCore.Mvc;
using GradProj.Application.DTO;
using System;
using System.Threading.Tasks;

namespace GradProj.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ReminderController : ControllerBase
    {
        private readonly IReminderService _reminderService;

        public ReminderController(IReminderService reminderService)
        {
            _reminderService = reminderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reminders = await _reminderService.GetAllAsync();
            return Ok(reminders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var reminder = await _reminderService.GetByIdAsync(id);
            if (reminder == null)
                return NotFound();

            return Ok(reminder);
        }

        [HttpPost]
        public async Task<IActionResult> SetReminder([FromBody] ReminderBaseDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _reminderService.CreateReminderAsync(dto);
            return Ok(new { message = "Reminder created successfully." });
        }
    }
}
