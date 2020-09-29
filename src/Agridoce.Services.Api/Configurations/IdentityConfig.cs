using Agridoce.Domain.Models;
using Agridoce.Infra.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Agridoce.Services.Api.Configurations
{
    public static class IdentityConfig
    {
        public static void AddIdentityConfiguration(this IServiceCollection services)
        {

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<AgridoceContext>()
                .AddDefaultTokenProviders();

            services
                  .Configure<IdentityOptions>(options =>
                  {
                      //Lockout
                      options.Lockout.AllowedForNewUsers = true;
                      options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                      options.Lockout.MaxFailedAccessAttempts = 5;

                      //Password
                      options.Password.RequireDigit = true;
                      options.Password.RequiredLength = 6;
                      options.Password.RequiredUniqueChars = 1;
                      options.Password.RequireLowercase = false;
                      options.Password.RequireUppercase = false;
                      options.Password.RequireNonAlphanumeric = false;

                      //SignIn
                      options.SignIn.RequireConfirmedEmail = false;
                      options.SignIn.RequireConfirmedPhoneNumber = false;

                      //User
                      options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                      options.User.RequireUniqueEmail = false;
                  });
        }
    }
}
