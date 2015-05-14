using System;
using Messages.Commands;
using Messages.Events;
using NServiceBus;

namespace Receiver.Preferred
{
    public class RegularCommandHandler : IHandleMessages<PreferredCommand>
    {
        public IBus Bus { get; set; }

        public void Handle(PreferredCommand message)
        {
            Console.WriteLine("got prefered command");
            Bus.Publish<NotifyEvent>(x =>x.Message = "came from preferred receiver. extra: " + message.Extra );    
        }
    }
}