using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradProj.Domain.Entities;

namespace GradProj.Application.ServiceAbs
{
    public interface INoteService: IService<Note>
    {
        List<Note> GetUserNotes(Guid userid);
    }
}
