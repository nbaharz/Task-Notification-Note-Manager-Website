using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradProj.Domain.RepositoryAbs;
using GradProj.Application.ServiceAbs;
using GradProj.Domain.Entities;

namespace GradProj.Application.ServiceImp
{
    public class GoalService : GenericService<Goal>, IGoalService 
    {
        private readonly IGoalRepository _goalRepository;
        public GoalService(IGoalRepository goalrepository) : base(goalrepository)
        {
            _goalRepository = goalrepository;
        }
    }
}
