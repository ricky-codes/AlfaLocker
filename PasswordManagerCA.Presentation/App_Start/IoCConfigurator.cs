using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Extras.CommonServiceLocator;
using Autofac.Features.Variance;
using Autofac.Integration.Mvc;
using CommonServiceLocator;
using MediatR;
using PasswordManager.Presentation.Controllers;
using PasswordManagerCA.Core.Commands;
using PasswordManagerCA.Core.Events;
using PasswordManagerCA.Core.Handlers.Command;
using PasswordManagerCA.Core.Handlers.Event;
using PasswordManagerCA.Core.Interfaces;
using PasswordManagerCA.Infrastructure.Data;
using PasswordManagerCA.Infrastructure.Data.Config;
using PasswordManagerCA.Infrastructure.Services;
using PasswordManagerCA.SharedKernel.Interfaces;

namespace PasswordManager.Presentation.App_Start
{
    public static class IoCConfigurator
    {
        public static void ConfigureDependencyInjection()
        {
            var builder = new ContainerBuilder();

            builder.RegisterSource(new ContravariantRegistrationSource());
            builder.RegisterAssemblyTypes(typeof(IMediator).Assembly).AsImplementedInterfaces();

            builder.RegisterType<AppDbModel>().InstancePerRequest();
            builder.RegisterType<EFRepository>().As<IRepository>();

            builder.RegisterType<PasswordHasher>().As<IPasswordHasher>();
            builder.RegisterType<PasswordEncrypt>().As<IPasswordEncrypt>();
            builder.RegisterType<EmailSender>().As<IEmailSender>();

            builder.RegisterType(typeof(UserRegistrationCommandHandler))
                .As<IRequestHandler<UserRegistrationCommand, UserRegistrationCommand>>()
                .AsImplementedInterfaces();
            builder.RegisterType(typeof(UserVerificationCommandHandler))
                .As<IRequestHandler<UserVerificationCommand, UserVerificationCommand>>()
                .AsImplementedInterfaces();
            builder.RegisterType(typeof(UserLoginCommandHandler))
                .As<IRequestHandler<UserLoginCommand, UserLoginCommand>>()
                .AsImplementedInterfaces();
            builder.RegisterType(typeof(UserSettingsUpdateCommandHandler))
                .As<IRequestHandler<UserSettingsUpdateCommand, UserSettingsUpdateCommand>>()
                .AsImplementedInterfaces();
            builder.RegisterType(typeof(UserSettingsCommandHandler))
                .As<IRequestHandler<UserSettingsCommand, UserSettingsUpdateCommand>>()
                .AsImplementedInterfaces();
            builder.RegisterType(typeof(UserAccountsCommandHandler))
                .As<IRequestHandler<UserAccountsCommand, List<UserAccountsCommand>>>()
                .AsImplementedInterfaces();
            builder.RegisterType(typeof(UserAccountsAddCommandHandler))
                .As<IRequestHandler<UserAccountsAddCommand, UserAccountsAddCommand>>()
                .AsImplementedInterfaces();
            builder.RegisterType(typeof(UserAccountsDeleteCommandHandler))
                .As<IRequestHandler<UserAccountsDeleteCommand, UserAccountsDeleteCommand>>()
                .AsImplementedInterfaces();
            builder.RegisterType(typeof(UserAccountsDetailsCommandHandler))
                .As<IRequestHandler<UserAccountsDetailsCommand, UserAccountsDetailsCommand>>()
                .AsImplementedInterfaces();
            builder.RegisterType(typeof(UserAccountsEditCommandHandler))
                .As<IRequestHandler<UserAccountsEditCommand, UserAccountsEditCommand>>()
                .AsImplementedInterfaces();
            builder.RegisterType(typeof(UserAccountsEditUpdateCommandHandler))
                .As<IRequestHandler<UserAccountsEditUpdateCommand, UserAccountsEditUpdateCommand>>()
                .AsImplementedInterfaces();
            builder.RegisterType(typeof(UserRegistrationNotificationHandler))
                .As<INotificationHandler<UserRegistrationNotification>>()
                .AsImplementedInterfaces();

            builder.RegisterControllers(typeof(HomeController).Assembly);
            builder.RegisterControllers(typeof(AccountController).Assembly);
            builder.RegisterControllers(typeof(ManageController).Assembly);

            builder.Register(x => new ServiceLocatorProvider(() => new AutofacServiceLocator(AutofacDependencyResolver.Current.RequestLifetimeScope))).InstancePerRequest();
            builder.Register<ServiceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}