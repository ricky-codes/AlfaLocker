using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PasswordManagerCA.Core.Interfaces;

namespace PasswordManagerCA.Core.Commands
{
    public class UserAccountsDetailsCommand : BaseCommand, IRequest<UserAccountsDetailsCommand>
    {
        public int Id { internal get; set; }

        [Display(Name = "Username")]
        public string AccountsUsername { get; set; }

        [Display(Name = "Password")]
        public string AccountPassword { get; set; }

        [Display(Name = "Website")]
        public string AccountWebsiteLink { get; set; }
    }
}
