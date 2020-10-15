using Agridoce.Domain.Commands.Requests.AccountCommand;
using FluentValidation;

namespace Agridoce.Domain.Commands.Validations.AccountValidation
{
    public class EmployeeUserAccountValidation<T> : UserAccountValidation<T> where T : EmployeeUserAccountCommand
    {
        protected void ValidateCompanyUserId()
        {
            RuleFor(c => c.CompanyId)
                .NotEmpty().WithMessage("Por favor informe o Identificador da Companhia.");
        }
    }
}
