using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradProj.Application.DTO;
using GradProj.Domain.Entities;

namespace GradProj.Application.ServiceAbs
{
    public interface IToDoService : IService<ToDo>
    {
        List<ToDo> GetSpecifiedUserTasks(Guid userid);
        Task CreateTaskAsync(TaskDto taskdto);
        //Task<List<ToDo>> EfCoreYukleyerekdeneme(Guid userid);

    }
}
