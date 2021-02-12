using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PasswordManagerCA.Core.Interfaces;

namespace PasswordManagerCA.Core.Commands
{
    public class CurrentUserCommand : BaseCommand, IRequest<UserManageCommand>
    {
        public int Id { get; set; }
    }
}
