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
    public class UserAccountsEditUpdateCommandHandler : IRequestHandler<UserAccountsEditUpdateCommand, UserAccountsEditUpdateCommand>
    {
        private readonly IRepository _repository;
        private readonly IMediator _mediator;
        private readonly IPasswordEncrypt _passwordEncrypt;


        public UserAccountsEditUpdateCommandHandler(IMediator mediator, IRepository repository, IPasswordEncrypt passwordEncrypt)
        {
            this._repository = repository;
            this._mediator = mediator;
            this._passwordEncrypt = passwordEncrypt;
        }

        public async Task<UserAccountsEditUpdateCommand> Handle(UserAccountsEditUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Accounts currentAccount = _repository.GetByID<Accounts>(request.Id);
                currentAccount.accountUsername = request.AccountsUsername;
                currentAccount.accountPasswordEncrypt = _passwordEncrypt.EncryptPassword(Globals.encryptKeyGlobal, request.AccountPassword);
                currentAccount.accountWebsiteLink = request.AccountWebsiteLink;
                _repository.Update<Accounts>(request.Id, currentAccount);
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
