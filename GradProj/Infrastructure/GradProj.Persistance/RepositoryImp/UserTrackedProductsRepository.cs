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
    public class UserTrackedProductsRepository : GenericRepository<UserTrackedProducts>, IUserTrackedProductsRepository
    {
        public UserTrackedProductsRepository(GradProjDbContext dbContext) : base(dbContext)
        {
        }

        public bool Exists(UserTrackedProducts userTrackedProducts)
        {
            return _dbSet.Any(us => us.UserId == userTrackedProducts.UserId && us.Id == userTrackedProducts.Id);
        }
    }
}
