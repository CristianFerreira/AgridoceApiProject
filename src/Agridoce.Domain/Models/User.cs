using Agridoce.Domain.Core;
using Agridoce.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace Agridoce.Domain.Models
{
    public class User : IdentityUser<Guid>, IEntity
    {
        
        [NotMapped]
        public string Token { get; private set; }
        [NotMapped]
        public IList<Claim> Claims { get; private set; }
        public UserType UserType { get; private set; }
        public EmployeeUser EmployeeUser { get; private set; }
        public CompanyUser CompanyUser { get; private set; }

        public User(Guid id, string email, IList<Claim> claims)
        {
            Id = id;
            Email = email;
            UserName = email;
            EmailConfirmed = true;
            AccessFailedCount = 0;
            LockoutEnabled = false;
            Claims = claims;
        }
        protected User() {}

        public void AddClaims(string type, string value)
        {
            Claims.Add(new Claim(type, value));
        }

        public IList<Claim> GetClaims() => Claims;

        public void SetToken(string token)
        {
            Token = token;
        }

        public string GetToken() => Token;
    }
}
