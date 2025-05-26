using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradProj.Application.DTO;
using GradProj.Application.ServiceAbs;
using GradProj.Domain.Entities;
using GradProj.Domain.RepositoryAbs;

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
        public async Task CreateTaskAsync(ToDo task, LoginDto User) // cerezde id saklamak yerine mail ve sifre ile tekrardan kullanici yi getirebiliriz.
        {
            var userholder = _userRepository.GetSingleAsync(x => x.Id == User.Id).FirstOrDefault();
            if (userholder == null)
            {
                throw new Exception("There is not such a User");
            }
            else
            {

                var userTask = new User_Tasks 
                {
                    TaskId = task.Id,
                    UserId = User.Id,
                  
                };
                await _repository.AddAsync(task);
                await _usertaskRepository.AddAsync(userTask);


            }



        }

    }
}
