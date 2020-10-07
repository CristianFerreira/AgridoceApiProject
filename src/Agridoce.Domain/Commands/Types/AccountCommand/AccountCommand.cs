using Agridoce.Domain.Core;
using Agridoce.Domain.Enums;
using System;

namespace Agridoce.Domain.Commands.Types.AccountCommand
{
    public class AccountCommand : Command
    {
        public Guid Id { get; protected set; }

        public UserType UserType { get; protected set; }

        public string Email { get; protected set; }

        public string Password { get; protected set; }

        public string ConfirmPassword { get; protected set; }
    }
}
