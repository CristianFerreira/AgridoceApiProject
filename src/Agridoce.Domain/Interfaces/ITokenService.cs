using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Agridoce.Domain.Interfaces
{
    public interface ITokenService
    {
        string NewToken(Guid id, IList<string> roles, IList<Claim> claims);
        bool IsValid(string token);
    }
}
