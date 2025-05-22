using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradProj.Domain.Entities;
using GradProj.Persistance.Contexts;
using GradProj.Domain.RepositoryAbs;

namespace GradProj.Persistance.RepositoryImp
{
    public class TodoRepository : GenericRepository<ToDo>, IToDoRepository
    {
        public TodoRepository(GradProjDbContext dbContext) : base(dbContext)
        {
        }
    }
}
