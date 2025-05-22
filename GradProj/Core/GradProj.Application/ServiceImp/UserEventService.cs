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
    public class UserEventService : GenericService<User_Events>, IUserEventService 
    {
        private readonly IUserEventRepository _userEventRepository;
        public UserEventService(IUserEventRepository userEventRepository) : base(userEventRepository)
        {
            _userEventRepository = userEventRepository;
        }
    }
}
