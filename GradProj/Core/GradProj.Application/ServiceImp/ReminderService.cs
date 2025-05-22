using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradProj.Application.Abstractions.Repository;
using GradProj.Application.ServiceAbs;
using GradProj.Domain.Entities;
using GradProj.Domain.RepositoryAbs;

namespace GradProj.Application.ServiceImp
{
    public class ReminderService : GenericService<Reminder>, IReminderService 
    {
        private readonly IReminderRepository _reminderRepository;
        public ReminderService(IReminderRepository reminderrepository) : base(reminderrepository)
        {
            _reminderRepository = reminderrepository;
        }
    }
}
