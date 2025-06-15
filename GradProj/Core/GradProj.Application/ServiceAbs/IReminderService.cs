using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradProj.Application.DTO;
using GradProj.Domain.Entities;

namespace GradProj.Application.ServiceAbs
{
    public interface IReminderService : IService<Reminder>
    {
        //public Task CreateTaskReminderAsync(Guid taskId, DateTime reminderTime, Guid userId, string message);

        // public Task CreateEventReminderAsync(Guid taskId, DateTime reminderTime, Guid userId, string message);
        public Task CreateTaskReminderAsync(ReminderTaskDto dto);
        public Task CreateEventReminderAsync(ReminderEventDto dto);

        

    }
}
