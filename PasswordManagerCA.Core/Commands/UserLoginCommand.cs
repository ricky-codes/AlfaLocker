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
    public class UserLoginCommand : BaseCommand, IRequest<UserLoginCommand>
    {
        [Required(ErrorMessage = "Please insert your email address")]
        [StringLength(60)]
        [EmailAddress(ErrorMessage = "This is not a valid email")]
        [Display(Name = "Email")]
        public string AppUserEmail { get; set; }

        [Required(ErrorMessage = "Please insert your password")]
        [StringLength(100)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string AppUserPassword { get; set; }

        public string AppUserFullname { get; internal set; }

        public string AppUserUsername { get; internal set; }

        public int Id { get; set; }
    }
}
