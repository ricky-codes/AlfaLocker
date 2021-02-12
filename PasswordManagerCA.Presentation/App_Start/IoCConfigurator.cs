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
using PasswordManagerCA.Core.Handlers.Command;
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

            builder.RegisterType(typeof(UserRegistrationCommandHandler))
                .As<IRequestHandler<UserRegistrationCommand, UserRegistrationCommand>>()
                .AsImplementedInterfaces();
            builder.RegisterType(typeof(UserVerificationCommandHandler))
                .As<IRequestHandler<UserVerificationCommand, UserVerificationCommand>>()
                .AsImplementedInterfaces();
            builder.RegisterType(typeof(UserLoginCommandHandler))
                .As<IRequestHandler<UserLoginCommand, UserLoginCommand>>()
                .AsImplementedInterfaces();
            builder.RegisterType(typeof(UserManageCommandHandler))
                .As<IRequestHandler<UserManageCommand, UserManageCommand>>()
                .AsImplementedInterfaces();
            builder.RegisterType(typeof(CurrentUserCommandHandler))
                .As<IRequestHandler<CurrentUserCommand, UserManageCommand>>()
                .AsImplementedInterfaces();

            builder.RegisterControllers(typeof(HomeController).Assembly);
            builder.RegisterControllers(typeof(AccountController).Assembly);

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