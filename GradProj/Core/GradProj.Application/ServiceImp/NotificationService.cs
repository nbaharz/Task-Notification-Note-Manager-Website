using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradProj.Application.ServiceAbs;
using GradProj.Domain.Entities;
using GradProj.Domain.RepositoryAbs;
using Microsoft.AspNetCore.SignalR;

namespace GradProj.Application.ServiceImp
{
    public class NotificationService : GenericService<Notification>, INotificationService
    {
        //notification isread oldugunda sil.
        private readonly INotificationRepository _notificationRepository;
        protected readonly IHubContext<NotificationHub> _hubContext;

        public NotificationService(INotificationRepository notificationRepository,IHubContext<NotificationHub> hubContext)
            : base(notificationRepository)
        {
            _notificationRepository = notificationRepository;
            _hubContext = hubContext;
        }

        public async Task CreateAsync(Notification notification)
        {
            notification.CreatedAt = DateTime.Now;
            await _notificationRepository.AddAsync(notification);

            await _hubContext.Clients
           .User(notification.UserId.ToString())
           .SendAsync("ReceiveNotification", notification);

            Console.WriteLine($"[SignalR] Bildirim gönderildi → User: {notification.UserId}, Title: {notification.Message}");
        }

        public async Task<IEnumerable<Notification>> GetNotificationsByUserIdAsync(Guid userId)
        {
            return await _notificationRepository.GetListGetWhere(n => n.UserId == userId);
        }

        public async Task MarkAsReadAsync(Guid notificationId)
        {
            var notif = await _notificationRepository.GetByIdAsync(notificationId);
            if (notif != null && !notif.IsRead)
            {
                notif.IsRead = true;
                _notificationRepository.UpdateAsync(notif);
            }
        }
    }
}
