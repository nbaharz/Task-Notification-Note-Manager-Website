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
    public class UserTaskService : GenericService<User_Tasks>, IUserTaskService 
    {
        private readonly IUserTaskRepository _userTaskRepository;
        public UserTaskService(IUserTaskRepository userTaskRepository) : base(userTaskRepository)
        {
            _userTaskRepository = userTaskRepository;
        }
    }
}
