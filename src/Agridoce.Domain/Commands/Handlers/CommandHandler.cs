using Agridoce.Domain.Core;
using Agridoce.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agridoce.Domain.Commands.Handlers
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

        protected void AddError(string message)
        {
            _bus.PublishEvent(new DomainNotification(string.Empty, message));
        }

        protected void AddError(IEnumerable<IdentityError> identityErrors)
        {
            foreach (var error in identityErrors)
            {
                _bus.PublishEvent(new DomainNotification(string.Empty, error.Description));
            }        
        }

        protected async Task PublishEventAsync(Event @event)
        {
            await _bus.PublishEvent(@event);
        }

        protected void PublishEvent(Event @event)
        {
            _bus.PublishEvent(@event);
        }

        protected async Task<ICommandResult> CreateResultAsync(object data = null)
        {
            return await Task.FromResult(new CommandResult(data));
        }

        protected ICommandResult CreateResult(object data = null)
        {
            return new CommandResult(data);
        }


        protected async Task<ICommandResult> CanceledTaskAsync()
        {
            return await Task.FromResult(new CommandResult());
        }

        protected ICommandResult CanceledTask()
        {
            return new CommandResult();
        }

    }
}
