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
    public class UserRegistrationCommand : BaseCommand, IRequest<UserRegistrationCommand>
    {
        [Required(ErrorMessage = "Please insert your username")]
        [StringLength(30)]
        [Display(Name = "Username")]
        public string AppUserUsername { get; set; }

        [Required(ErrorMessage = "Please insert your email address")]
        [StringLength(60)]
        [EmailAddress(ErrorMessage = "This is not a valid email")]
        [Display(Name = "Email")]
        public string AppUserEmail { get; set; }

        [StringLength(30)]
        [Required(ErrorMessage = "Please insert your firstname")]
        [Display(Name = "Firstname")]
        public string AppUserFirstname { get; set; }

        [Required(ErrorMessage = "Please insert your lastname")]
        [StringLength(30)]
        [Display(Name = "Lastname")]
        public string AppUserLastname { get; set; }

        [Required(ErrorMessage = "Please insert your phone number")]
        [Display(Name = "Phone number")]
        [RegularExpression("9[1236][0-9]{7}|2[1-9][0-9]{7}", ErrorMessage = "This is not a valid PT-PT phone number")]
        public int? AppUserPhoneNumber { get; set; }

        [Required(ErrorMessage = "Please insert your password")]
        [StringLength(100)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string AppUserPassword { get; set; }

        [Required(ErrorMessage = "Please confirm your password")]
        [StringLength(100)]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("AppUserPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string AppUserConfirmationPassword { get; set; }

        public int Id { get; internal set; }
    }
}
