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
    public class UserAccountsAddCommandHandler : IRequestHandler<UserAccountsAddCommand, UserAccountsCommand>
    {
        private readonly IRepository _repository;
        private readonly IMediator _mediator;
        private readonly IPasswordHasher _passwordHasher;


        public UserAccountsAddCommandHandler(IMediator mediator, IRepository repository, IPasswordHasher passwordHasher)
        {
            this._repository = repository;
            this._mediator = mediator;
            this._passwordHasher = passwordHasher;
        }

        public async Task<UserAccountsCommand> Handle(UserAccountsAddCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Accounts accountCreated = _repository.Insert<Accounts>(new Accounts 
                {
                    accountUsername = request.Username,
                    accountPasswordHash = request.PasswordHash,
                    accountPasswordSalt = request.PasswordSalt,
                    accountWebsiteLink = request.WebsiteLink,
                    accountAppUser = request.UserId
                });
                AppUsers currentUser = _repository.GetByID<AppUsers>(request.UserId);
                UserAccountsCommand userAccounts = new UserAccountsCommand();
                userAccounts.UserAccounts.Add(accountCreated);
                userAccounts.isValid = true;
                return userAccounts;
            }
            catch(Exception ex)
            {
                string er = ex.InnerException.ToString();
                request.isValid = false;
                return request;
            }
        }
    }
}
