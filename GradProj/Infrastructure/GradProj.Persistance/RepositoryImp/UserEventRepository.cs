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
    public class UserEventRepository: GenericRepository<User_Events>, IUserEventRepository
    {
        public UserEventRepository(GradProjDbContext dbContext): base(dbContext)
        {
            
        }
    }
}
