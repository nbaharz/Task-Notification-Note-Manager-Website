using GradProj.Application.ServiceAbs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradProj.API.Controllers
{
    //Service-controller kullanimini gozumde canlandirmak icin 
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IToDoService _toDoService;
        public TaskController(IToDoService toDoService)
        {
            _toDoService= toDoService;
        }

    }
}
