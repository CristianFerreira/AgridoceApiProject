using Agridoce.Domain.Core;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

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
            Claims = new List<Claim>();
        }

        protected IList<Claim> Claims { get; set; }
        [NotMapped]
        protected string Token { get; set; }

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
