using Agridoce.Domain.Commands.Validations.AccountValidation.Commands;
using Agridoce.Domain.Enums;
using System;

namespace Agridoce.Domain.Commands.Requests.AccountCommand
{
    public class RegisterEmployeeUserAccountCommand : EmployeeUserAccountCommand
    {
        public RegisterEmployeeUserAccountCommand(Guid companyId, string email, string password, string confirmPassword)
        {
            CompanyId = companyId;
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
            UserType = UserType.Employee;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterEmployeeUserAccountCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
