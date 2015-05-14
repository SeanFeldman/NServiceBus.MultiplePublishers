using NServiceBus;

namespace Messages.Events
{
    public interface NotifyEvent : IEvent
    {
        string Message { get; set; }
    }
}