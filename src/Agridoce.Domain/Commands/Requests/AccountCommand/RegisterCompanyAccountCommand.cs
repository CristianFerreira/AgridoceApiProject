using Agridoce.Domain.Enums;
using System;

namespace Agridoce.Domain.Commands.Requests.AccountCommand
{
    public class RegisterCompanyAccountCommand : AccountCommand
    {
        public string Name { get; }

        public RegisterCompanyAccountCommand(string name, string email, string password, string confirmPassword)
        {
            Name = name;
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
            UserType = UserType.Company;
        }     
    }
}
