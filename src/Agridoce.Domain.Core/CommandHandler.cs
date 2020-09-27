using MediatR;
using System.Threading.Tasks;

namespace Agridoce.Domain.Core
{
    public abstract class CommandHandler
    {
        private readonly IMediatorHandler _bus;
        protected readonly DomainNotificationHandler _notifications;

        public CommandHandler(IMediatorHandler bus,
                              INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _bus = bus;
        }

        protected void AddError(string key, string message)
        {
            _bus.PublishEvent(new DomainNotification(key, message));
        }

        protected async Task PublishEventAsync(Event @event)
        {
            await _bus.PublishEvent(@event);
        }

        protected void PublishEvent(Event @event)
        {
            _bus.PublishEvent(@event);
        }

        protected async Task<ICommandResult> CompletedTask(IEntity data = null)
        {
            return await Task.FromResult(new CommandResult(data));
        }

        protected async Task<ICommandResult> CanceledTask()
        {
            return await Task.FromResult(new CommandResult());
        }

    }
}
