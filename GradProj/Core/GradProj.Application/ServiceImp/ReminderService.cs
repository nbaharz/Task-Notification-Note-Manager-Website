using GradProj.Application.DTO;
using GradProj.Application.ServiceAbs;
using GradProj.Domain.Entities;
using GradProj.Domain.RepositoryAbs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;


namespace GradProj.Application.ServiceImp
{
    public class ReminderService : GenericService<Reminder>, IReminderService
    {
        //reminder hatirlatildiginda sil.
        private readonly IReminderRepository _reminderRepository;

        public ReminderService(IReminderRepository reminderRepository) : base(reminderRepository)
        {
            _reminderRepository = reminderRepository;
        }

        public async Task CreateReminderAsync(ReminderBaseDto dto)
        {
            var reminder = new Reminder
            {
                UserId = dto.UserId,
                ReferenceID = dto.ReferenceId,
                ReminderTime = dto.ReminderTime,
                Message = dto.Message,
                referenceType = dto.ReferenceType
            };

            await _reminderRepository.AddAsync(reminder);
        }
       
      
        public List<Reminder> GetUserSpecifiedReminders(Guid userid)
        {
            return _reminderRepository.GetSingleAsync(u => u.UserId == userid).ToList();
        }

     
    }
}
