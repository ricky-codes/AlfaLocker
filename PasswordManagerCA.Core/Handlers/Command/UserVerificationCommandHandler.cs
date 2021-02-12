using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PasswordManagerCA.Core.Commands;
using PasswordManagerCA.Core.Entities;
using PasswordManagerCA.Core.Interfaces;
using PasswordManagerCA.SharedKernel.Interfaces;

namespace PasswordManagerCA.Core.Handlers.Command
{
    public class UserVerificationCommandHandler : IRequestHandler<UserVerificationCommand, UserVerificationCommand>
    {

        private readonly IRepository _repository;
        private readonly IMediator _mediator;
        private readonly IPasswordHasher _passwordHasher;


        public UserVerificationCommandHandler(IMediator mediator, IRepository repository, IPasswordHasher passwordHasher)
        {
            this._repository = repository;
            this._mediator = mediator;
            this._passwordHasher = passwordHasher;
        }

        public async Task<UserVerificationCommand> Handle(UserVerificationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                AppUsers currentUser = _repository.GetByID<AppUsers>(request.Id);
                if(currentUser.appUsersVerificationCode == request.UserVerificationCode)
                {
                    currentUser.isVerified = true;
                    _repository.Update<AppUsers>(currentUser.Id, currentUser);
                    request.isValid = true;
                }
                return request;
            }
            catch
            {
                request.isValid = false;
                return request;
            }
        }
    }
}
