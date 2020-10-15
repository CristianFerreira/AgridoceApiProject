using Agridoce.Application.Interfaces;
using Agridoce.Application.Services;
using Agridoce.Domain.Commands.Handlers;
using Agridoce.Domain.Commands.Requests.AccountCommand;
using Agridoce.Domain.Commands.Validations;
using Agridoce.Domain.Core;
using Agridoce.Domain.Factories;
using Agridoce.Domain.Interfaces;
using Agridoce.Domain.Interfaces.Repositories;
using Agridoce.Domain.Services;
using Agridoce.Infra.CrossCutting.Bus;
using Agridoce.Infra.Data.Context;
using Agridoce.Infra.Data.Repositories;
using Agridoce.Infra.Data.UoW;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Agridoce.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        private static IServiceCollection _services;

        public static void RegisterServices(IServiceCollection services)
        {
            _services = services;

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITokenService, TokenService>();

            // Domain - Commands            
            services.AddScoped<IRequestHandler<LoginAccountCommand, ICommandResult>, AccountCommandHandler>();
            services.AddScoped<IRequestHandler<RegisterCompanyUserAccountCommand, ICommandResult>, AccountCommandHandler>();
            services.AddScoped<IRequestHandler<RegisterEmployeeUserAccountCommand, ICommandResult>, AccountCommandHandler>();

            //Handler
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            //Context
            services.AddScoped<AgridoceContext>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Repository
            services.AddScoped<ICompanyUserRepository, CompanyUserRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            //factory
            services.AddScoped<IUserClaimFactory, UserClaimFactory>();

            //validation
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastValidation<,>));



        }

    }
}
