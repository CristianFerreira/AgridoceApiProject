using Microsoft.AspNetCore.Http;

namespace Agridoce.Services.Api.Extensions
{
    public class ValidateAdminAccountCustomAuthorizer : IValidateCustomAuthorizer
    {
        private readonly HttpContext _context;

        public ValidateAdminAccountCustomAuthorizer(HttpContext context)
        {
            _context = context;
        }

        public bool IsAuthenticated()
        {
            return _context.User.Identity.IsAuthenticated;
        }

        public bool IsValidPermission()
        {
            return true;                      
        }
    }
}
