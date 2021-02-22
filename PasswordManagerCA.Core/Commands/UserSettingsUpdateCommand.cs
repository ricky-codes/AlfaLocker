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
    public class UserSettingsUpdateCommand : BaseCommand, IRequest<UserSettingsUpdateCommand>
    {
        [StringLength(30)]
        [Display(Name = "Username")]
        public string AppUserUsername { get; set; }

        [StringLength(60)]
        [EmailAddress(ErrorMessage = "This is not a valid email")]
        [Display(Name = "Email")]
        public string AppUserEmail { get; set; }

        [StringLength(30)]
        [Display(Name = "Firstname")]
        public string AppUserFirstname { get; set; }

        [StringLength(30)]
        [Display(Name = "Lastname")]
        public string AppUserLastname { get; set; }

        [Display(Name = "Phone number")]
        [RegularExpression("9[1236][0-9]{7}|2[1-9][0-9]{7}", ErrorMessage = "This is not a valid PT-PT phone number")]
        public int AppUserPhoneNumber { get; set; }


        public int Id { get; set; }
    }
}
