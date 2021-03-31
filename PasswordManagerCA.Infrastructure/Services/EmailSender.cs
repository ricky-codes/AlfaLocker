using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using PasswordManagerCA.Core.Interfaces;
using PasswordManagerCA.SharedKernel;

namespace PasswordManagerCA.Infrastructure.Services
{
    public class EmailSender : IEmailSender
    {
        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");

        public EmailSender()
        {
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(Globals.emailService, Globals.emailPasswordService);
            smtpClient.EnableSsl = true;
        }

        public void SendEmailSync(string to, string from, string subject, string body)
        {
            smtpClient.Send(Globals.emailService, to, subject, "Your verification code is" + body);
        }
    }
}
