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
    public class EventService<T> : GenericService<Event>, IEventService where T : BaseEntity
    {
        private readonly IEventRepository eventRepository;
        public EventService(IEventRepository repository) : base(repository)
        {
            eventRepository = repository;
        }
    }
}
