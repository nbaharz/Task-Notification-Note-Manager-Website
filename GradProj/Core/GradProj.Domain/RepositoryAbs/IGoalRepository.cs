using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradProj.Domain.Entities;
using GradProj.Domain.RepositoryAbs;

namespace GradProj.Application.Abstractions.Repository
{
    public interface IGoalRepository: IRepository<Goal>
    {
    }
}
