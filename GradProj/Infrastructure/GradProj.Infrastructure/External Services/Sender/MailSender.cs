using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradProj.Application.ServiceAbs;
using GradProj.Infrastructure.External_Services.Mailkit;

namespace GradProj.Infrastructure.External_Services.Sender
{
    public class MailSender : ISender
    {
        private readonly IMailKitService _mailKitService;
        public MailSender(IMailKitService mailKitService)
        {
            _mailKitService = mailKitService;

        }

        public  async Task SendMailkitAsync(string to, string subject, string body)
        {
            await _mailKitService.SendEmailAsync(to, subject, body);
        }
    }
}
