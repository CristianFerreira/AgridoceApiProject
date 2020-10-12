using Agridoce.Domain.Core;
using Agridoce.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Agridoce.Domain.Models
{
    public class User : IdentityUser<Guid>, IEntity
    {
        public User(Guid id, string email)
        {
            Id = id;
            Email = email;
            UserName = email;
            EmailConfirmed = true;
            AccessFailedCount = 0;
            LockoutEnabled = false;
        }
        protected User() {}

        public UserType UserType { get; private set; }
        public ICollection<CompanyUser> CompanyUsers { get; private set; }
    }
}
