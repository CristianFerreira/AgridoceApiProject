using System;

namespace Agridoce.Domain.Commands
{
    public class RegisterNewTestCommand : TestCommand
    {
        public RegisterNewTestCommand(string name, int age)
        {
            Id = Guid.NewGuid();
            Name = name;
            Age = age;
        }
    }
}
