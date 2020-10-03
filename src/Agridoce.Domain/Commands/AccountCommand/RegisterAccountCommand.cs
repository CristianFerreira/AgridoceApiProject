using System;

namespace Agridoce.Domain.Commands.AccountCommand
{
    public class RegisterAccountCommand : AccountCommand
    {
        public RegisterAccountCommand(string email, string password, string confirmPassword)
        {
            Id = Guid.NewGuid();
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
        }
    }
}
