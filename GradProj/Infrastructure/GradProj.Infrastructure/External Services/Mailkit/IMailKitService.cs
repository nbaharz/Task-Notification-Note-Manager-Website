using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradProj.Infrastructure.External_Services.Mailkit
{
    public interface IMailKitService
    {
        Task SendEmailAsync(string toEmail, string subject, string body);
    }
}
