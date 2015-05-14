using System;
using Messages.Commands;
using Messages.Events;
using NServiceBus;

namespace Receiver.Regular
{
    public class RegularCommandHandler : IHandleMessages<RegularCommand>
    {
        public IBus Bus { get; set; }

        public void Handle(RegularCommand message)
        {
            Console.WriteLine("got regular command");
            Bus.Publish<NotifyEvent>(x =>x.Message = "came from regular receiver" );    
        }
    }
}