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
    public class UserAccountsCommandHandler : IRequestHandler<UserAccountsCommand, UserAccountsCommand>
    {
        private readonly IRepository _repository;
        private readonly IMediator _mediator;
        private readonly IPasswordHasher _passwordHasher;


        public UserAccountsCommandHandler(IMediator mediator, IRepository repository, IPasswordHasher passwordHasher)
        {
            this._repository = repository;
            this._mediator = mediator;
            this._passwordHasher = passwordHasher;
        }

        public async Task<UserAccountsCommand> Handle(UserAccountsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                AppUsers currentUser = _repository.GetByID<AppUsers>(request.Id);
                request.UserAccounts = currentUser.Accounts.ToList();
                request.isValid = true;
                return request;
            }
            catch(Exception ex)
            {
                string err = ex.Message;
                request.isValid = false;
                return request;
            }
        }
    }
}
