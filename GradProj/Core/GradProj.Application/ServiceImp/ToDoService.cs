using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradProj.Application.Abstractions.Repository;
using GradProj.Application.ServiceAbs;
using GradProj.Domain.Entities;
using GradProj.Domain.RepositoryAbs;

namespace GradProj.Application.ServiceImp
{
    public class ToDoService<T> : GenericService<ToDo>, IToDoService where T : BaseEntity
    {
        private readonly IToDoRepository _toDoRepository;
        public ToDoService(IToDoRepository toDoRepository) : base(toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }
    }
}
