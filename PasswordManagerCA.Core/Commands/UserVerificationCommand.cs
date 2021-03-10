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
    public class UserVerificationCommand : BaseCommand, IRequest<UserVerificationCommand>
    {
        [Required(ErrorMessage = "Please insert your verification code")]
        [Display(Name = "Verification Code")]
        public int? UserVerificationCode { get; set; }

        public int Id { get; set; }

        
    }
}
