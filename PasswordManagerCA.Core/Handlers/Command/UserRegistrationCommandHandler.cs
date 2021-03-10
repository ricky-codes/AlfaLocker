using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PasswordManagerCA.Core.Commands;
using PasswordManagerCA.Core.Entities;
using PasswordManagerCA.Core.Events;
using PasswordManagerCA.Core.Interfaces;
using PasswordManagerCA.Core.Services;
using PasswordManagerCA.SharedKernel.Interfaces;

namespace PasswordManagerCA.Core.Handlers.Command
{
    public class UserRegistrationCommandHandler : IRequestHandler<UserRegistrationCommand, UserRegistrationCommand>
    {
        private readonly IRepository _repository;
        private readonly IMediator _mediator;
        private readonly IPasswordHasher _passwordHasher;


        public UserRegistrationCommandHandler(IMediator mediator, IRepository repository, IPasswordHasher passwordHasher)
        {
            this._repository = repository;
            this._mediator = mediator;
            this._passwordHasher = passwordHasher;
        }

        public async Task<UserRegistrationCommand> Handle(UserRegistrationCommand request, CancellationToken cancellationToken)
        {

            AppUsers userToRegister = new AppUsers
            {
                appUsersEmail = request.AppUserEmail,
                appUsersUsername = request.AppUserUsername,
                appUsersFirstname = request.AppUserFirstname,
                appUsersLastname = request.AppUserLastname,
                appUsersPhoneNumber = (int)request.AppUserPhoneNumber,
                appUsersVerificationCode = new VerificationCode(6).VerificationCodeNumber,
                appUsersPasswordHash = _passwordHasher.Hash(request.AppUserPassword),
                createdAt = DateTime.Now,
                isVerified = false
            };

            try
            {
                int returnedID = _repository.Insert<AppUsers>(userToRegister).id;
                
                await _mediator.Publish(new UserRegistrationNotification
                {
                    AppUserEmail = userToRegister.appUsersEmail,
                    AppUserVerificationCode = (int)userToRegister.appUsersVerificationCode,
                });
                request.isValid = true;
                request.Id = returnedID;

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
