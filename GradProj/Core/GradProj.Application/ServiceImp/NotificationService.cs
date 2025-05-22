using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradProj.Application.ServiceAbs;
using GradProj.Domain.Entities;
using GradProj.Domain.RepositoryAbs;

namespace GradProj.Application.ServiceImp
{
    public class NotificationService : GenericService<Notification>, INotificationService 
    {
        private readonly INotificationRepository _notificationRepository;
        public NotificationService(INotificationRepository notificationRepository) : base(notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }
    }
}
