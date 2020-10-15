using Agridoce.Domain.Commands.Requests.AccountCommand;
using FluentValidation;
using FluentValidation.Results;

namespace Agridoce.Domain.Commands.Validations.AccountValidation
{
    public class UserAccountValidation<T> : AbstractValidator<T> where T : UserAccountCommand
    {
        public override ValidationResult Validate(ValidationContext<T> context)
        {
            if (context.InstanceToValidate == null)
                return new ValidationResult(new[] { new ValidationFailure("Account", "Por favor informe os dados da conta do usuario!") });

            return base.Validate(context);
        }

        protected void ValidateEmail()
        => RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Por favor insira um valor para o e-mail")
                .EmailAddress().WithMessage("Por favor informe um e-mail valido!")
                .MaximumLength(256).WithMessage("O E-mail deve ter no máximo 256 caracteres");


        protected void ValidatePasswordEqualsConfirmPassword()
        => RuleFor(c => c.Password)
                .Equal(c => c.ConfirmPassword).WithMessage("A senha e a confirmação de senha devem ter o mesmo valor");


        protected void ValidatePassword()
        => RuleFor(c => c.Password)
                .NotEmpty().WithMessage("Por favor insira um valor para a senha")
                .Length(6, 12).WithMessage("A senha deve ter entre 6 e 12 caracteres");

    }
}
