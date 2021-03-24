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
using PasswordManagerCA.SharedKernel;

namespace PasswordManagerCA.Core.Handlers.Command
{
    public class UserAccountsEditCommandHandler : IRequestHandler<UserAccountsEditCommand, UserAccountsEditCommand>
    {
        private readonly IRepository _repository;
        private readonly IMediator _mediator;
        private readonly IPasswordEncrypt _passwordEncrypt;


        public UserAccountsEditCommandHandler(IMediator mediator, IRepository repository, IPasswordEncrypt passwordEncrypt)
        {
            this._repository = repository;
            this._mediator = mediator;
            this._passwordEncrypt = passwordEncrypt;
        }

        public async Task<UserAccountsEditCommand> Handle(UserAccountsEditCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Accounts currentAccount = _repository.GetByID<Accounts>(request.Id);
                return new UserAccountsEditCommand
                {
                    AccountsUsername = currentAccount.accountUsername,
                    AccountPassword = _passwordEncrypt.DecryptPassword(Globals.encryptKeyGlobal, currentAccount.accountPasswordEncrypt),
                    AccountWebsiteLink = currentAccount.accountWebsiteLink,
                    isValid = true
                };
            }
            catch
            {
                request.isValid = false;
                return request;
            }
        }
    }
}
