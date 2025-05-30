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
    public class NoteRepository : GenericRepository<Note>, INoteRepository
    {
        public NoteRepository(GradProjDbContext dbContext) : base(dbContext)
        {
        }
    }
}
