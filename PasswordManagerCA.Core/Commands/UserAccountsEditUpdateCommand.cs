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
    public class UserAccountsEditUpdateCommand : BaseCommand, IRequest<UserAccountsEditUpdateCommand>
    {
        public int Id { internal get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "You must enter a username")]
        public string AccountsUsername { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "You must enter a password")]
        public string AccountPassword { get; set; }

        [Display(Name = "Website")]
        public string AccountWebsiteLink { get; set; }
    }
}
