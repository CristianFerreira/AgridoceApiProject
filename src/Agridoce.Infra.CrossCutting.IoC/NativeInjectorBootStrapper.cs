using Agridoce.Application.Interfaces;
using Agridoce.Application.Services;
using Agridoce.Domain.Commands;
using Agridoce.Domain.Commands.Handlers;
using Agridoce.Domain.Core;
using Agridoce.Infra.CrossCutting.Bus;
using MediatR;
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
            services.AddScoped<ITestService, TestService>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewTestCommand, ICommandResult>, TestCommandHandler>();

            //Handler
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
        }

    }
}
