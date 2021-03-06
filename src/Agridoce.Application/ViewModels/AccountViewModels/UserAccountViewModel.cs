﻿using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Agridoce.Application.ViewModels.AccountViewModels
{
    public class UserAccountViewModel
    {
        public UserAccountViewModel(Guid userId, string email, string token, IList<Claim> claims)
        {
            UserId = userId;
            Email = email;
            Token = token;
            Claims = TransformAccountClaimViewModel(claims);
        }

        public Guid UserId { get; }
        public string Email { get; }
        public string Token { get; }
        public IList<AccountClaimViewModel> Claims { get; }

        private IList<AccountClaimViewModel> TransformAccountClaimViewModel(IList<Claim> claims)
        {
            var list = new List<AccountClaimViewModel>();
            foreach (var claim in claims)
                list.Add(new AccountClaimViewModel(claim.Type, claim.Value));

            return list; 
        }
    }
}
