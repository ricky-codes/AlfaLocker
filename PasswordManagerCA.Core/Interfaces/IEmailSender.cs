using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagerCA.Core.Interfaces
{
    public interface IEmailSender
    {
        void SendEmailSync(string to, string from, string subject, string body);
    }
}
