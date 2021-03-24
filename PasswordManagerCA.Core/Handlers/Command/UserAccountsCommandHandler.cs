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
    public class UserAccountsCommandHandler : IRequestHandler<UserAccountsCommand, List<UserAccountsCommand>>
    {
        private readonly IRepository _repository;
        private readonly IMediator _mediator;
        private readonly IPasswordEncrypt _passwordEncrypt;


        public UserAccountsCommandHandler(IMediator mediator, IRepository repository, IPasswordEncrypt passwordEncrypt)
        {
            this._repository = repository;
            this._mediator = mediator;
            this._passwordEncrypt = passwordEncrypt;
        }

        public async Task<List<UserAccountsCommand>> Handle(UserAccountsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                List<Accounts> currentUserAccounts = _repository.GetAll<Accounts>().Where(u => u.AppUsers.id == request.UserId).ToList();
                List<UserAccountsCommand> userAccounts = new List<UserAccountsCommand>();

                foreach (Accounts account in currentUserAccounts)
                {
                    userAccounts.Add(new UserAccountsCommand
                    {
                        AccountWebsiteLink = account.accountWebsiteLink,
                        Id = account.id,
                        isValid = true
                    }); 
                }
                return userAccounts;
            }
            catch
            {
                return null;
            }
        }
    }
}
