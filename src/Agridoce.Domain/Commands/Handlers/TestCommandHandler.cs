using Agridoce.Domain.Core;
using Agridoce.Domain.Interfaces;
using Agridoce.Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Agridoce.Domain.Commands.Handlers
{
    public class TestCommandHandler : CommandHandler,
          IRequestHandler<RegisterNewTestCommand, ICommandResult>
    {
        private readonly ITestRepository _testRepository;

        public TestCommandHandler(IUnitOfWork uow,
                                  ITestRepository testRepository,
                                  IMediatorHandler mediator,
                                  INotificationHandler<DomainNotification> notifications) : base(uow, mediator, notifications)
        {
            _testRepository = testRepository;
        }

        public Task<ICommandResult> Handle(RegisterNewTestCommand request, CancellationToken cancellationToken)
        {
            var error = false;
            if (error)
            {
                AddError(request.MessageType, "testando mensagem de erro!");
                return CanceledTask();
            }

            var test = new Test(request.Id, request.Name);
            _testRepository.Add(test);

            Commit();
            return CompletedTask(test);
        }
    }
}
