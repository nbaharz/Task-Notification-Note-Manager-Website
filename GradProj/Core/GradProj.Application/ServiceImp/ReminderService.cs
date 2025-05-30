using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradProj.Application.DTO;
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

        //reminder service denemeleri -b
    
        public async Task CreateTaskReminderAsync(ReminderTaskDto dto)
        {
            var reminder = new Reminder
            {
                UserId = dto.UserId,
                ReferenceID = dto.TaskId,
                ReminderTime = dto.ReminderTime,
                Message = dto.Message,
                referenceType = ReferenceType.Task
            };

            await _reminderRepository.AddAsync(reminder);
        }

        public async Task CreateEventReminderAsync(ReminderEventDto dto)
        {
            var reminder = new Reminder
            {
                UserId = dto.UserId,
                ReferenceID = dto.EventId,
                ReminderTime = dto.ReminderTime,
                Message = dto.Message,
                referenceType = ReferenceType.Event
            };

            await _reminderRepository.AddAsync(reminder);
        }


    }
}
