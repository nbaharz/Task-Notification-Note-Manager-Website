using GradProj.Application.DTO;
using GradProj.Application.ServiceAbs;
using GradProj.Application.ServiceImp;
using GradProj.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        [HttpGet("{id}")]
        public IActionResult GetUserTasks(Guid id)
        {
            var tasks = _toDoService.GetSpecifiedUserTasks(id);
            if (tasks == null) return NotFound();
            return Ok(tasks);
        }
        [HttpPut]
        public IActionResult CreateTask(TaskDto taskdto)
        {
        
            _toDoService.CreateTaskAsync(taskdto);
            return Ok(taskdto);

        }

    }
}
