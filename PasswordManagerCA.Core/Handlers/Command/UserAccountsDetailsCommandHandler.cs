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
    public class UserAccountsDetailsCommandHandler : IRequestHandler<UserAccountsDetailsCommand, UserAccountsDetailsCommand>
    {
        private readonly IRepository _repository;
        private readonly IMediator _mediator;
        private readonly IPasswordEncrypt _passwordEncrypt;


        public UserAccountsDetailsCommandHandler(IMediator mediator, IRepository repository, IPasswordEncrypt passwordEncrypt)
        {
            this._repository = repository;
            this._mediator = mediator;
            this._passwordEncrypt = passwordEncrypt;
        }

        public async Task<UserAccountsDetailsCommand> Handle(UserAccountsDetailsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Accounts requestedAccount = _repository.GetByID<Accounts>(request.Id);
                UserAccountsDetailsCommand requestedDetails = new UserAccountsDetailsCommand
                {
                    AccountsUsername = requestedAccount.accountUsername,
                    AccountPassword = _passwordEncrypt.DecryptPassword(Globals.encryptKeyGlobal, requestedAccount.accountPasswordEncrypt),
                    AccountWebsiteLink = requestedAccount.accountWebsiteLink
                };
                requestedDetails.isValid = true;
                return requestedDetails;
            }
            catch
            {
                request.isValid = false;
                return request;
            }
        }
    }
}
