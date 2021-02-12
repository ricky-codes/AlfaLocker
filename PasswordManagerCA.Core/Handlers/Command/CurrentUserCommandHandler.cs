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
    public class CurrentUserCommandHandler : IRequestHandler<CurrentUserCommand, UserManageCommand>
    {
        private readonly IRepository _repository;
        private readonly IMediator _mediator;
        private readonly IPasswordHasher _passwordHasher;


        public CurrentUserCommandHandler(IMediator mediator, IRepository repository, IPasswordHasher passwordHasher)
        {
            this._repository = repository;
            this._mediator = mediator;
            this._passwordHasher = passwordHasher;
        }

        public async Task<UserManageCommand> Handle(CurrentUserCommand request, CancellationToken cancellationToken)
        {
            AppUsers currentUser = _repository.GetByID<AppUsers>(request.Id);
            return new UserManageCommand
            {
                AppUserEmail = currentUser.appUsersEmail,
                AppUserFirstname = currentUser.appUsersFirstname,
                AppUserLastname = currentUser.appUsersLastname,
                AppUserPhoneNumber = currentUser.appUsersPhoneNumber,
                AppUserUsername = currentUser.appUsersUsername,
                isValid = null
            };

        }
    }
}
