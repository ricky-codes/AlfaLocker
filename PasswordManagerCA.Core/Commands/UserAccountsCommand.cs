using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PasswordManagerCA.Core.Entities;
using PasswordManagerCA.Core.Interfaces;

namespace PasswordManagerCA.Core.Commands
{
    public class UserAccountsCommand : BaseCommand, IRequest<List<UserAccountsCommand>>
    {
        public int Id { get; internal set; }

        [Display(Name = "Website")]
        public string AccountWebsiteLink { get; set; }

        public int UserId { get; set; }

        public int WebsiteAccountsCount { get; set; }
    }
}
