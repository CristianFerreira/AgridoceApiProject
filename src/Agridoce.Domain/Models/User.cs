using Agridoce.Domain.Core;
using Microsoft.AspNetCore.Identity;
using System;

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
            LockoutEnabled = true;
        }
    }
}
