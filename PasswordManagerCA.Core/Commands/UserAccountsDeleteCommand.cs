using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PasswordManagerCA.Core.Interfaces;

namespace PasswordManagerCA.Core.Commands
{
    public class UserAccountsDeleteCommand : BaseCommand, IRequest<UserAccountsDeleteCommand>
    {
        public int Id { get; set; }
    }
}
