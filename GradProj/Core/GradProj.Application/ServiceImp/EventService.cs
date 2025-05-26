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

        public  async Task CreateEventAsync(Event Event, LoginDto User) // cerezde id saklamak yerine mail ve sifre ile tekrardan kullanici yi getirebiliriz.
        {
            var userholder = _userRepository.GetSingleAsync(x=> x.Id==User.UserId).FirstOrDefault();
            if (userholder == null)
            {
                throw new Exception("There is not such a User");
            }
            else {           

                var userevent = new User_Events
                {
                    EventId = Event.Id,
                    UserId = User.UserId
                     // ← required property burada set edildi
                
                };
                await _repository.AddAsync(Event);
                await _userEventRepository.AddAsync(userevent);


            }



        }
    }
}
