using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PasswordManagerCA.Core.Interfaces;

namespace PasswordManagerCA.Core.Commands
{
    public class UserSettingsCommand : BaseCommand, IRequest<UserSettingsUpdateCommand>
    {
        public int Id { get; set; }
    }
}
