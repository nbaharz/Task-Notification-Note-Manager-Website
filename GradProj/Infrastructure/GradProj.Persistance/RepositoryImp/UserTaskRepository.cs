using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradProj.Domain.Entities;
using GradProj.Domain.RepositoryAbs;
using GradProj.Persistance.Contexts;


namespace GradProj.Persistance.RepositoryImp
{
    public class UserTaskRepository : GenericRepository<User_Tasks>, IUserTaskRepository
    {
        public UserTaskRepository(GradProjDbContext dbContext) : base(dbContext)
        {
        }
    }
}
