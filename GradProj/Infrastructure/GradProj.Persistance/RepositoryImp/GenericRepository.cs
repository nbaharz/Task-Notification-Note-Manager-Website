using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradProj.Domain.Entities;
using GradProj.Domain.RepositoryAbs;
using GradProj.Persistance.Contexts;


namespace GradProj.Domain.RepositoryConcretes
{
    public class GenericRepository<TEntity>: IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly GradProjDbContext _dbContext;

        public GenericRepository(GradProjDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
