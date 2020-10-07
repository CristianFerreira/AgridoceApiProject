using Agridoce.Domain.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Agridoce.Services.Api.Configurations
{
    public static class ClaimConfig
    {
        public static void AddClaimConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<List<ClaimConfiguration>>(configuration.GetSection("ClaimsDefaultSettings"));
        }
    }
}
