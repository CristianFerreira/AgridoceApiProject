namespace Agridoce.Domain.Core
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(dynamic data = null) => Data = data;
        public dynamic Data { get; private set; }
    }
}
