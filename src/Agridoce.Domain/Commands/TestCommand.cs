using Agridoce.Domain.Core;
using System;

namespace Agridoce.Domain.Commands
{
    public abstract class TestCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public int Age { get; protected set; }
    }
}
