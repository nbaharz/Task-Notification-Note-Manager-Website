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
    public class EventService : GenericService<Event>, IEventService
    {
        protected readonly IEventRepository eventRepository;
        protected readonly IUserRepository _userRepository;
        protected readonly IUserEventRepository _userEventRepository;


        public EventService(IEventRepository repository, IUserRepository userRepository, IUserEventRepository userEventRepository) : base(repository)
        {
            eventRepository = repository;
            _userRepository = userRepository;
            _userEventRepository = userEventRepository;
        }

        public  async Task CreateEventAsync(EventDto eventDto) // cerezde id saklamak yerine mail ve sifre ile tekrardan kullanici yi getirebiliriz.
        {
            var userholder = _userRepository.GetSingleAsync(x=> x.Id== eventDto.UserId).FirstOrDefault();
            if (userholder == null)
            {
                throw new Exception("There is not such a User");
            }
            else {


                var event1 = new Event
                {
                    UserId = userholder.Id,
                    Title = eventDto.Title,
                    Description = eventDto.Description,
                    EventDate = eventDto.EventDate
                };
                await _repository.AddAsync(event1);
                var userevent = new User_Events
                {
                    UserId = userholder.Id,
                    EventId = event1.Id,
                   

                };
                await _userEventRepository.AddAsync(userevent);


            }



        }

        public List<Event> GetSpecifiedUserEvents(Guid userid)
        {
            return _repository.GetSingleAsync(u => u.UserId == userid).ToList();
        }
    }
}
