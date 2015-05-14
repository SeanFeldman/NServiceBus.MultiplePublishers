using NServiceBus;

namespace Messages.Commands
{
    public class RegularCommand : ICommand
    {
        public string Description { get; set; }
    }
}
