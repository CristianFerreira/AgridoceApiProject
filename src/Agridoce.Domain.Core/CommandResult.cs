namespace Agridoce.Domain.Core
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(IEntity data = null) => Data = data;
        public IEntity Data { get; private set; }
    }
}
