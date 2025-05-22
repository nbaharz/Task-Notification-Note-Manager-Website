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
    public class GoalService<T> : GenericService<Goal>, IGoalService where T : BaseEntity
    {
        private readonly IGoalRepository _goalRepository;
        public GoalService(IGoalRepository goalrepository) : base(goalrepository)
        {
            _goalRepository = goalrepository;
        }
    }
}
