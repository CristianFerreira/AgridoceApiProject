using Agridoce.Domain.Commands.Validations.AccountValidation.Commands;
using Agridoce.Domain.Enums;

namespace Agridoce.Domain.Commands.Requests.AccountCommand
{
    public class RegisterCompanyUserAccountCommand : CompanyUserAccountCommand
    {
        public RegisterCompanyUserAccountCommand(string name, string email, string password, string confirmPassword)
        {
            Name = name;
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
            UserType = UserType.Company;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterCompanyUserAccountCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
