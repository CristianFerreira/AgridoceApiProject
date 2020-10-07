using Agridoce.Domain.Enums;
using System;

namespace Agridoce.Domain.Commands.Types.AccountCommand
{
    public class RegisterCompanyAccountCommand : AccountCommand
    {
        public string Name { get; }

        public RegisterCompanyAccountCommand(string name, string email, string password, string confirmPassword)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
            UserType = UserType.Company;
        }     
    }
}
