using Agridoce.Domain.Configurations;
using Agridoce.Domain.Enums;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

namespace Agridoce.Domain.Factories
{
    public class UserClaimFactory : IUserClaimFactory
    {
        private readonly Dictionary<UserType, Func<IClaim>> map;

        public UserClaimFactory(IOptions<List<ClaimConfiguration>> claimConfigurations)
        {
            map = new Dictionary<UserType, Func<IClaim>>
            {
                { UserType.Company, () => (new CompanyClaim(claimConfigurations.Value))},
                { UserType.Employee, () => (new EmployeeClaim(claimConfigurations.Value))},
                { UserType.Admin, () => (new AdminClaim(claimConfigurations.Value))},
            };
        }

        public IClaim Create(UserType userType)
        {
            if (!map.TryGetValue(userType, out var createClaimGenerator))
            {
                throw new ArgumentException($"User type not found: {userType}");
            }

            return createClaimGenerator();
        }

    }
}
