using Agridoce.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;

namespace Agridoce.Services.Api.Extensions
{
    public class CustomAuthorizerStrategy
    {
        public IValidateCustomAuthorizer Create(HttpContext context, string claimName, string claimValue)
        {
            if (context.User.IsInRole(RoleType.Admin.ToString()))
            {
                return new ValidateAdminAccountCustomAuthorizer(context);
            }
            else if (context.User.IsInRole(RoleType.Employee.ToString()) || context.User.IsInRole(RoleType.Company.ToString()))
            {
                return new ValidateAccountCustomAuthorizer(context, claimName, claimValue);
            }

            throw new ArgumentException("CustomAuthorizerStrategy not implemented!");
        }


    }
}
