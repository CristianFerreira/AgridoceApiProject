using Agridoce.Domain.Core;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Agridoce.Domain.Commands.Validations
{
    public class FailFastValidation<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : Command where TResponse : class
    {
        private readonly IValidator _validators;
        private readonly IMediatorHandler _bus;
        private readonly DomainNotificationHandler _notifications;

        public FailFastValidation(IValidator<TRequest> validators, 
                                  IMediatorHandler bus, 
                                  INotificationHandler<DomainNotification> notifications)
        {
            _validators = validators;
            _bus = bus;
            _notifications = (DomainNotificationHandler)notifications;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (request.IsValid())
                return next();

            NotifyValidationErrors(request.ValidationResult, request);
            return Task.FromResult(new CommandResult() as TResponse);
        }

        private void NotifyValidationErrors(ValidationResult result, TRequest request)
        {
            foreach (var error in result.Errors)
                _bus.PublishEvent(new DomainNotification(request.MessageType, error.ErrorMessage));

        }

    }

}
