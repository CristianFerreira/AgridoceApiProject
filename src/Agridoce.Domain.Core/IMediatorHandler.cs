using System.Threading.Tasks;

namespace Agridoce.Domain.Core
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T @event) where T : Event;
        Task<ICommandResult> SendCommand<T>(T command) where T : Command;
    }
}
