using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PasswordManagerCA.Core.Entities;
using PasswordManagerCA.Core.Services;

namespace PasswordManagerCA.Core.Events
{
    public class UserRegistrationNotification : INotification
    {
        public string AppUserEmail { get; set; }
        public int AppUserVerificationCode { get; set; }
    }
}
