using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradProj.Domain.Entities;

namespace GradProj.Application.ServiceAbs
{
    public interface IToDoService : IService<ToDo>
    {
        List<ToDo> GetSpecifiedUserTasks(Guid userid);
        //Task<List<ToDo>> EfCoreYukleyerekdeneme(Guid userid);
        
    }
}
