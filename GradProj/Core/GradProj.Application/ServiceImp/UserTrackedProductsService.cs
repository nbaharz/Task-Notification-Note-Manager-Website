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
    public class UserTrackedProductsService: GenericService<UserTrackedProducts>, IUserTrackedProductsService 
    {
        private readonly IUserTrackedProductsRepository _userTrackedProductsRepository;
        public UserTrackedProductsService(IUserTrackedProductsRepository userTrackedProductsRepository) : base(userTrackedProductsRepository)
        {
            _userTrackedProductsRepository = userTrackedProductsRepository;
        }
    }
}
