using Agridoce.Domain.Configurations;
using Agridoce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Agridoce.Domain.Factories
{
    public class EmployeeClaim : IClaim
    {
        private readonly List<ClaimConfiguration> _claimConfigurations;

        public EmployeeClaim(List<ClaimConfiguration> claimConfigurations)
        {
            _claimConfigurations = claimConfigurations;
        }

        public IList<Claim> Get()
        {
            return _claimConfigurations
                         .Where(x => x.AllowedBy.Contains(RoleType.Employee.ToString(), StringComparer.OrdinalIgnoreCase))
                                .Select(x => new Claim(x.Type, string.Join(",", x.Values))).ToList();
        }
    }
}
