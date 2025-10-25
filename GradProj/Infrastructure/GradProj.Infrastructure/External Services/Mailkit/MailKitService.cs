
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;



namespace GradProj.Infrastructure.External_Services.Mailkit
{
    public class MailKitService : IMailKitService
    {
        private readonly IConfiguration _config;
        public MailKitService(IConfiguration config)
        {
            _config = config;
        }
        public  async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var email = new MimeKit.MimeMessage();
            email.From.Add(new MailboxAddress(
                _config["EmailSettings:SenderName"],
                _config["EmailSettings:SenderEmail"]
            ));
            email.To.Add(MailboxAddress.Parse(toEmail));
            email.Subject = subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = body
            };
            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(
               _config["EmailSettings:SmtpServer"],
               int.Parse(_config["EmailSettings:Port"]),
               SecureSocketOptions.StartTls
           );
            await smtp.AuthenticateAsync(
             _config["EmailSettings:SenderEmail"],
             _config["EmailSettings:Password"]
         );
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);

        }
    }
}
