using Agridoce.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Agridoce.Infra.Data.Configurations
{
    public static class IdentityConfig
    {
        public static void AddIdentityTableConfiguration(this ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("Users");

            builder.Entity<IdentityRole<Guid>>().ToTable("Roles");

            builder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");

            builder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles");

            builder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins");

            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");

            builder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens");
        }
    }
}
