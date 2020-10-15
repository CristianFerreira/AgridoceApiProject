using Agridoce.Domain.Commands.Requests.AccountCommand;

namespace Agridoce.Domain.Commands.Validations.AccountValidation.Commands
{
    public class RegisterCompanyUserAccountCommandValidation : CompanyUserAccountValidation<RegisterCompanyUserAccountCommand>
    {
        public RegisterCompanyUserAccountCommandValidation()
        {
            ValidateName();
            ValidateEmail();
            ValidatePassword();
            ValidatePasswordEqualsConfirmPassword();
        }
    }
}
