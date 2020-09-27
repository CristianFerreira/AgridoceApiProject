using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Agridoce.Services.Api.Configurations
{
    public static class MediatRConfig
    {
        public static void AddMediatRConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

           var x =  AppDomain.CurrentDomain.GetAssemblies();

            var assembly = AppDomain.CurrentDomain.Load("Agridoce.Domain");
            AssemblyScanner
                .FindValidatorsInAssembly(assembly)
                .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

            services.AddMediatR(typeof(Startup).Assembly);
        }
    }
}
