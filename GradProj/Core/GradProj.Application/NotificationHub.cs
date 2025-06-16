using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradProj.Domain.Entities;
using Microsoft.AspNetCore.SignalR;

namespace GradProj.Application
{
    public class NotificationHub :Hub
    {
        public async Task SendNotificationToUser(string userId, Notification notification)
        {
            await Clients.User(userId).SendAsync("ReceiveNotification", notification);
        }
    }
}
