using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradProj.Application.DTO;
using GradProj.Domain.Entities;

namespace GradProj.Application.ServiceAbs
{
    public interface IEventService : IService<Event>
    {
        Task CreateEventAsync(EventDto eventDto);
        List<Event> GetSpecifiedUserEvents(Guid userid);
    }
}
