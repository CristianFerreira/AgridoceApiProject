using Agridoce.Domain.Commands.Requests.AccountCommand;
using FluentValidation;

namespace Agridoce.Domain.Commands.Validations.AccountValidation
{
    public class CompanyUserAccountValidation<T> : UserAccountValidation<T> where T : CompanyUserAccountCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Por favor informe o Nome da Companhia.")
                .MaximumLength(256).WithMessage("O Nome da Companhia deve ter no máximo 256 caracteres");
        }
    }
}
