
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradProj.Application.ServiceAbs;
using GradProj.Domain.Entities;
using GradProj.Domain.RepositoryAbs;

namespace GradProj.Application.ServiceImp
{
    public class UserService : GenericService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository repository) : base(repository)
        {
            _userRepository = repository;
        }
    }
}
