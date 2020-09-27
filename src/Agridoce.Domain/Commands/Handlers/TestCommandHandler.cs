using Agridoce.Domain.Core;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Agridoce.Domain.Commands.Handlers
{
    public class TestCommandHandler : CommandHandler,
          IRequestHandler<RegisterNewTestCommand, ICommandResult>
    {

        public TestCommandHandler(IMediatorHandler mediator,
                                  INotificationHandler<DomainNotification> notifications) : base(mediator, notifications)
        {
        }

        public Task<ICommandResult> Handle(RegisterNewTestCommand request, CancellationToken cancellationToken)
        {
            var error = true;
            if (error)
            {
                AddError(request.MessageType, "testando mensagem de erro!");
                return CanceledTask();
            }

            return CompletedTask();
        }
    }
}
