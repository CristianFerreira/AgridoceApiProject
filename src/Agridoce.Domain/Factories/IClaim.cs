using System.Collections.Generic;
using System.Security.Claims;

namespace Agridoce.Domain.Factories
{
    public interface IClaim
    {
        IList<Claim> Get();
    }
}
