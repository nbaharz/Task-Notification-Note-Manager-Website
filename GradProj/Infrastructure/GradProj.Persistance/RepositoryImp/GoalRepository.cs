using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradProj.Domain.RepositoryAbs;
using GradProj.Domain.Entities;
using GradProj.Persistance.Contexts;

namespace GradProj.Persistance.RepositoryImp
{
    public class GoalRepository : GenericRepository<Goal>, IGoalRepository
    {
        public GoalRepository(GradProjDbContext dbContext) : base(dbContext)
        {
        }
    }
}
