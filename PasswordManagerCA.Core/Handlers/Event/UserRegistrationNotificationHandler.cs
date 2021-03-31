using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PasswordManagerCA.Core.Events;
using PasswordManagerCA.Core.Interfaces;
using PasswordManagerCA.SharedKernel;

namespace PasswordManagerCA.Core.Handlers.Event
{
    public class UserRegistrationNotificationHandler : INotificationHandler<UserRegistrationNotification>
    {
        private IEmailSender _emailSender { get; set; }

        public UserRegistrationNotificationHandler(IEmailSender emailSender)
        {
            this._emailSender = emailSender;
        }

        public Task Handle(UserRegistrationNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                _emailSender.SendEmailSync(notification.AppUserEmail, Globals.emailService, "MyPassword - Confirmation code", notification.AppUserVerificationCode.ToString());
            });
        }
    }
}
