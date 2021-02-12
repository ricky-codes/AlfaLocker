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
    public class UserManageCommandHandler : IRequestHandler<UserManageCommand, UserManageCommand>
    {
        private readonly IRepository _repository;
        private readonly IMediator _mediator;
        private readonly IPasswordHasher _passwordHasher;


        public UserManageCommandHandler(IMediator mediator, IRepository repository, IPasswordHasher passwordHasher)
        {
            this._repository = repository;
            this._mediator = mediator;
            this._passwordHasher = passwordHasher;
        }

        public async Task<UserManageCommand> Handle(UserManageCommand request, CancellationToken cancellationToken)
        {
            try
            {
                AppUsers user = _repository.GetByID<AppUsers>(request.Id);
                user.appUsersFirstname = request.AppUserFirstname;
                user.appUsersLastname = request.AppUserLastname;
                user.appUsersPhoneNumber = request.AppUserPhoneNumber;
                user.appUsersUsername = request.AppUserUsername;
                _repository.Update<AppUsers>(request.Id, user);

                request.isValid = true;
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
