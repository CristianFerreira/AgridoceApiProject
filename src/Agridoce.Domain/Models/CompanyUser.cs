using Agridoce.Domain.Core;
using System;

namespace Agridoce.Domain.Models
{
    public class CompanyUser
    {
        public CompanyUser(Company company, User user)
        {
            CompanyId = company.Id;
            UserId = user.Id;
            Company = company;
            User = user;
        }

        protected  CompanyUser() {}

        public Guid CompanyId { get; }
        public Guid UserId { get; }
        public Company Company { get; }
        public User User { get; }
    }
}
