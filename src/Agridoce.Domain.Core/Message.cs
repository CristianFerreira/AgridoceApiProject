using MediatR;

namespace Agridoce.Domain.Core
{
    public abstract class Message : IRequest<ICommandResult>
    {
        public string MessageType { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}
