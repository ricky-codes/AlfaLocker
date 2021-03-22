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
    public class UserAccountsAddCommand : BaseCommand, IRequest<UserAccountsAddCommand>
    {
        public int Id { get; internal set; }

        [Display(Name = "Username")]
        public string AccountsUsername { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "You must enter a password")]
        public string AccountPassword { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "You need to confirm your password")]
        [Compare("AccountPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string AccountPasswordConfirmation { get; set; }

        [Display(Name = "Website")]
        public string AccountWebsiteLink { get; set; }

        public int UserId { get; set; }
    }
}
