using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Agridoce.Services.Api.Configurations
{
    public static class TokenConfig
    {
        public static void AddTokenConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var tokenAppSettingsSection = configuration.GetSection("TokenAppSetings");
            services.Configure<TokenAppSetings>(tokenAppSettingsSection);

            var tokenAppSettings = tokenAppSettingsSection.Get<TokenAppSetings>();
            var key = Encoding.ASCII.GetBytes(tokenAppSettings.SecretKey);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = tokenAppSettings.Audience,
                    ValidIssuer = tokenAppSettings.Issuer
                };
            });
        }
    }
}
