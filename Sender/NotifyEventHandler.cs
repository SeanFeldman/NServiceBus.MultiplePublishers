using System;
using Messages.Events;
using NServiceBus;

namespace Sender
{
    public class NotifyEventHandler : IHandleMessages<NotifyEvent>
    {
        public void Handle(NotifyEvent message)
        {
            Console.WriteLine("received event. message: " + message.Message);
        }
    }
}