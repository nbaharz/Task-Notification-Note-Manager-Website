using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradProj.Application.DTO;
using GradProj.Application.ServiceAbs;
using GradProj.Domain.Entities;
using GradProj.Domain.RepositoryAbs;
using Microsoft.EntityFrameworkCore;


namespace GradProj.Application.ServiceImp
{
    public class ToDoService : GenericService<ToDo>, IToDoService 
    {
        private readonly IToDoRepository _toDoRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserTaskRepository _usertaskRepository;
        public ToDoService(IToDoRepository toDoRepository, IUserRepository userRepository, IUserTaskRepository usertaskRepository) : base(toDoRepository)
        {
            _toDoRepository = toDoRepository;
            _userRepository = userRepository;
            _usertaskRepository = usertaskRepository;
        }
        public async Task CreateTaskAsync(TaskDto taskdto, Guid id ) // cerezde id saklamak yerine mail ve sifre ile tekrardan kullanici yi getirebiliriz.
        {
            if (id == Guid.Empty)
                throw new Exception("There is not such a User");
            else
            {

              
                var task = new ToDo
                {
                    UserId = id,
                    Title = taskdto.Title,
                    Description = taskdto.Description,
                    Priority = taskdto.Priority,

                };
             
                await _repository.AddAsync(task);
                var userTask = new User_Tasks
                {

                    UserId = id,
                    TaskId = task.Id,

                };
                await _usertaskRepository.AddAsync(userTask);

            }
        }    

        public List<ToDo> GetSpecifiedUserTasks(Guid userid)
        {
           return _toDoRepository.GetSingleAsync(u=> u.UserId == userid).ToList();

        }
        //public async Task<List<ToDo>> EfCoreYukleyerekdeneme(Guid userid)
        //{
        //    var tasks = await _usertaskRepository
        // .GetListGetWhere(ut => ut.UserId == userid)
        // .Select(ut => ut.ToDo)    // navigation property ToDo olmalı
        // .Where(td => td != null)
        // .ToListAsync();

        //    return tasks;
        //}

    }
}


