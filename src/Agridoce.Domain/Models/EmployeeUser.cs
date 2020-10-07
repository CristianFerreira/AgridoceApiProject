using Agridoce.Domain.Core;
using System;

namespace Agridoce.Domain.Models
{
    public class EmployeeUser : IEntity
    {
        protected EmployeeUser() { }
        public Guid Id { get; set; }
        public Guid CompanyUserId { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public CompanyUser CompanyUser { get; set; }
        public User User { get; set; }
    }
}
