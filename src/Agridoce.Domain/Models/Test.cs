using Agridoce.Domain.Core;
using System;

namespace Agridoce.Domain.Models
{
    public class Test :IEntity
    {
        public Test(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
