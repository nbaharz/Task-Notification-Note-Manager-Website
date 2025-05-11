using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradProj.Domain.RepositoryAbs;
using GradProj.Domain.Entities;

namespace GradProj.Application.Abstractions.Repository
{
    public interface IEventRepository:IRepository<Event>
    {
    }
}
