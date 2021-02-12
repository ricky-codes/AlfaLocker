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
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, UserLoginCommand>
    {
        private readonly IRepository _repository;
        private readonly IMediator _mediator;
        private readonly IPasswordHasher _passwordHasher;


        public UserLoginCommandHandler(IMediator mediator, IRepository repository, IPasswordHasher passwordHasher)
        {
            this._repository = repository;
            this._mediator = mediator;
            this._passwordHasher = passwordHasher;
        }

        public async Task<UserLoginCommand> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                AppUsers user = _repository.GetAll<AppUsers>().Where(u => u.appUsersEmail == request.AppUserEmail).FirstOrDefault();
                if (_passwordHasher.Verify(request.AppUserPassword, user.appUsersPasswordHash))
                {
                    request.isValid = true;
                    request.Id = user.Id;
                    request.AppUserUsername = user.appUsersUsername;
                    request.AppUserFullname = user.appUsersFirstname + " " + user.appUsersLastname;
                }
                else
                {
                    request.isValid = false;
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
