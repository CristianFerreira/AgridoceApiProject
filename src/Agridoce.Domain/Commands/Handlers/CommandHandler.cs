using Agridoce.Domain.Core;
using Agridoce.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace Agridoce.Domain
{
    public abstract class CommandHandler
    {
        protected readonly IUnitOfWork _uow;
        private readonly IMediatorHandler _bus;
        protected readonly DomainNotificationHandler _notifications;

        public CommandHandler(IUnitOfWork uow,
                              IMediatorHandler bus,
                              INotificationHandler<DomainNotification> notifications)
        {
            _uow = uow;
            _notifications = (DomainNotificationHandler)notifications;
            _bus = bus;
        }

        protected bool Commit(IDbContextTransaction transaction = null)
        {
            if (_notifications.HasNotifications()) return false;
            if (_uow.Commit(transaction)) return true;

            AddError("Commit", "Ocorreu um problema ao salvar seus dados.");
            return false;
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
