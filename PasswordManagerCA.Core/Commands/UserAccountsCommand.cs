using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PasswordManagerCA.Core.Entities;
using PasswordManagerCA.Core.Interfaces;

namespace PasswordManagerCA.Core.Commands
{
    public class UserAccountsCommand : BaseCommand, IRequest<UserAccountsCommand>
    {
        public int Id { get; set; }
        public List<Accounts> UserAccounts { get; set; }
    }
}
