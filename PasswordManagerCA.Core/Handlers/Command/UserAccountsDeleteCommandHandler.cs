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
using PasswordManagerCA.SharedKernel;
using PasswordManagerCA.SharedKernel.Interfaces;

namespace PasswordManagerCA.Core.Handlers.Command
{
    public class UserAccountsDeleteCommandHandler : IRequestHandler<UserAccountsDeleteCommand, UserAccountsDeleteCommand>
    {
        private readonly IRepository _repository;
        private readonly IMediator _mediator;
        private readonly IPasswordEncrypt _passwordEncrypt;


        public UserAccountsDeleteCommandHandler(IMediator mediator, IRepository repository, IPasswordEncrypt passwordEncrypt)
        {
            this._repository = repository;
            this._mediator = mediator;
            this._passwordEncrypt = passwordEncrypt;
        }

        public async Task<UserAccountsDeleteCommand> Handle(UserAccountsDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _repository.Delete<Accounts>(request.Id);
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
