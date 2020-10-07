using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace Agridoce.Services.Api.Extensions
{
    public class CustomAuthorization
    {
        public class CustomAuthorizeAttribute : TypeFilterAttribute
        {
            public CustomAuthorizeAttribute(string claimName, string claimValue) : base(typeof(ClaimFilterRequirement))
            {
                Arguments = new object[] { new Claim(claimName, claimValue) };
            }
        }

        public class ClaimFilterRequirement : IAuthorizationFilter
        {
            private readonly Claim _claim;

            public ClaimFilterRequirement(Claim claim)
            {
                _claim = claim;
            }

            public void OnAuthorization(AuthorizationFilterContext context)
            {
                var customAuthorizerStrategy = new CustomAuthorizerStrategy().Create(context.HttpContext, _claim.Type, _claim.Value);

                if (!customAuthorizerStrategy.IsAuthenticated())
                {
                    context.Result = new StatusCodeResult(401);
                }
                else if (!customAuthorizerStrategy.IsValidPermission())
                {
                    context.Result = new StatusCodeResult(403);
                }
            }
        }
    }
}
