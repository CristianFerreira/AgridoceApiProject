using Agridoce.Domain.Enums;
using System;

namespace Agridoce.Domain.Commands.Requests.AccountCommand
{
    public class RegisterEmployeeAccountCommand : AccountCommand
    {
        public string Name { get; }
        public Guid CompanyUserId { get; set; }

        public RegisterEmployeeAccountCommand(string name, Guid companyUserId, string email, string password, string confirmPassword)
        {
            Name = name;
            CompanyUserId = companyUserId;
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
            UserType = UserType.Employee;
        }
    }
}
