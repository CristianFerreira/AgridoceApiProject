using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Agridoce.Domain.Commands.Responses
{
    public class AccountCommandResult
    {
        public AccountCommandResult(Guid userId, string email, string token, IList<Claim> claims)
        {
            UserId = userId;
            Email = email;
            Token = token;
            AccountClaims = claims;
        }

        public Guid UserId { get; }
        public string Email { get; }
        public string Token { get; }
        public IList<Claim> AccountClaims { get; }
    }
}
