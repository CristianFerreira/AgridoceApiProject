using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace Agridoce.Services.Api.Extensions
{
    public class ValidateAccountCustomAuthorizer : IValidateCustomAuthorizer
    {
        private readonly HttpContext _context;
        private readonly string _clainName;
        private readonly string _claimValue;

        public ValidateAccountCustomAuthorizer(HttpContext context, string claimName, string claimValue)
        {
            _context = context;
            _clainName = claimName;
            _claimValue = claimValue;
        }

        public bool IsAuthenticated()
        {
            return _context.User.Identity.IsAuthenticated;
        }

        public bool IsValidPermission()
        {
            return _context.User.Identity.IsAuthenticated &&
                   _context.User.Claims.Any(c => c.Type == _clainName && c.Value.Split(',').Contains(_claimValue));
        }
    }
}
