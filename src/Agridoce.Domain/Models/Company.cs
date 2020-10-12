using Agridoce.Domain.Core;
using System;
using System.Collections.Generic;

namespace Agridoce.Domain.Models
{
    public class Company : IEntity
    {
        public Company(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        protected Company() { }

        public Guid Id { get; }
        public string Name { get; }
        public ICollection<CompanyUser> CompanyUsers { get; private set; }
    }
}
