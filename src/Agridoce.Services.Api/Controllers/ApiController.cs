using Agridoce.Domain.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Agridoce.Services.Api.Controllers
{
    public abstract class ApiController : ControllerBase
    {
        private readonly DomainNotificationHandler _notifications;
        protected ApiController(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
        }

        protected bool IsValidOperation() => (!_notifications.HasNotifications());

        protected new IActionResult Response(dynamic result)
        {
            if (IsValidOperation())
            {
                return Ok(new
                {
                    success = true,
                    data = (result is ICommandResult) ? result.Data : result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notifications.GetNotifications().Select(n => n.Value)
            });
        }
    }
}
