using Agridoce.Domain.Commands.Requests.AccountCommand;

namespace Agridoce.Domain.Commands.Validations.AccountValidation.Commands
{
    public class RegisterEmployeeUserAccountCommandValidation : EmployeeUserAccountValidation<RegisterEmployeeUserAccountCommand>
    {
        public RegisterEmployeeUserAccountCommandValidation()
        {
            ValidateEmail();
            ValidatePassword();
            ValidatePasswordEqualsConfirmPassword();
        }
    }
}
