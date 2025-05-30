using GradProj.Application.ServiceAbs;
using GradProj.Application.ServiceImp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GradProj.Application.DTO;

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
            return Ok(reminder);
        }

        [HttpPost]
        //SetReminder denemesi
        public IActionResult SetTaskReminder(ReminderTaskDto dto) 
            //async Task<IActionResult> neye gore yapariz: database islemi varsa olabilir
        {
            var taskReminder = _reminderService.CreateTaskReminderAsync(dto);
            if (taskReminder == null) 
            { 
                return NotFound();
            }
            return Ok(taskReminder);
        }
    }
}
