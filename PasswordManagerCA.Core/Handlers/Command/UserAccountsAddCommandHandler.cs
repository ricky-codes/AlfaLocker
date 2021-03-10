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
    public class UserAccountsAddCommandHandler : IRequestHandler<UserAccountsAddCommand, UserAccountsAddCommand>
    {
        private readonly IRepository _repository;
        private readonly IMediator _mediator;
        private readonly IPasswordEncrypt _passwordEncrypt;


        public UserAccountsAddCommandHandler(IMediator mediator, IRepository repository, IPasswordEncrypt passwordEncrypt)
        {
            this._repository = repository;
            this._mediator = mediator;
            this._passwordEncrypt = passwordEncrypt;
        }

        public async Task<UserAccountsAddCommand> Handle(UserAccountsAddCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _repository.Insert<Accounts>(new Accounts 
                { 
                    accountUsername = request.AccountsUsername,
                    accountPasswordEncrypt = _passwordEncrypt.EncryptPassword(Globals.encryptKeyGlobal, request.AccountPassword),
                    accountWebsiteLink = request.AccountWebsiteLink,
                    accountAppUser = request.UserId
                });
                request.isValid = true;
                return request;
            }
            catch(Exception err)
            {
                string eee = err.InnerException.ToString();
                request.isValid = false;
                return request;
            }
        }
    }
}
