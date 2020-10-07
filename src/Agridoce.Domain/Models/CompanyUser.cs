using Agridoce.Domain.Core;
using System;
using System.Collections.Generic;

namespace Agridoce.Domain.Models
{
    public class CompanyUser : IEntity
    {
        protected  CompanyUser() {}
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
        public ICollection<EmployeeUser> EmployeeUsers { get; private set; }
    }
}
