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
    public class ReminderRepository : GenericRepository<Reminder>, IReminderRepository
    {
        public ReminderRepository(GradProjDbContext dbContext) : base(dbContext)
        {
        }
    }
}
