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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(GradProjDbContext dbContext) : base(dbContext)
        {
        }
    }
}
