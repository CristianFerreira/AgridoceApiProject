using Agridoce.Domain.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Agridoce.Services.Api.Controllers
{
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        private readonly DomainNotificationHandler _notifications;
        protected ApiController(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
        }

        protected bool IsValidOperation() => (!_notifications.HasNotifications());

        protected new IActionResult Response(dynamic result = null)
        {
            if (IsValidOperation())
            {
                return Ok(new SuccessfulResponse<dynamic>
                {
                    Data = (result is ICommandResult) ? result.Data : result
                });
            }

            return BadRequest(new ErrorResponse
            {
                Errors = _notifications.GetNotifications().Select(n => n.Value)
            });
        }
    }

    public class SuccessfulResponse<T>
    {
        public SuccessfulResponse()
        {
            Success = true;
        }

        public bool Success { get; set; }
        public T Data { get; set; }
    }

    public class ErrorResponse
    {
        public ErrorResponse()
        {
            Success = false;
            Errors = new List<string>();
        }

        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
