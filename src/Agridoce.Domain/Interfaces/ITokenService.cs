using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Agridoce.Domain.Interfaces
{
    public interface ITokenService
    {
        string NewToken(Guid key, IList<Claim> claims);
        bool IsValid(string token);
    }
}
