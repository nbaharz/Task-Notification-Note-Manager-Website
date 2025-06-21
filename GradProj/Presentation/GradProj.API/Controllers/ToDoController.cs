using GradProj.Application.DTO;
using GradProj.Application.ServiceAbs;
using GradProj.Application.ServiceImp;
using GradProj.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace GradProj.API.Controllers
{
    
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ToDoController : ControllerBase
    {
        protected IToDoService _toDoService;
        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
            
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var toDos = await _toDoService.GetAllAsync();
            return Ok(toDos);
        }
        [HttpGet("{id}")]
        public  async Task<IActionResult> GetById(Guid id)
        {
            var event1 = await _toDoService.GetByIdAsync(id);
            if (event1 == null) return NotFound();
            return Ok(event1);
        }
        [HttpPut]
        public IActionResult Update(ToDo toDo)
        {
            _toDoService.UpdateAsync(toDo);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _toDoService.DeleteAsync(id);
            return NoContent();
        }
        [Authorize]
        [HttpPost]
        public IActionResult GetUserTasks()
        {
            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var tasks = _toDoService.GetSpecifiedUserTasks(userId);
            if (tasks == null) return NotFound();
            return Ok(tasks);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskDto taskdto)
        {
            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            await _toDoService.CreateTaskAsync(taskdto, userId);
            return Ok(taskdto);

        }

    }
}
