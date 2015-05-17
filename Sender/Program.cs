using System;
using Messages.Commands;
using NServiceBus;

namespace Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new BusConfiguration();
            configuration.EndpointName("x-sender");
            configuration.UseTransport<AzureServiceBusTransport>().ConnectionString("Endpoint=sb://seanfeldman-test.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=");
            configuration.UsePersistence<InMemoryPersistence>();
            configuration.UseSerialization<JsonSerializer>();
            configuration.EnableInstallers();
            using (var bus = Bus.Create(configuration))
            {
                bus.Start();
                Run(bus);
            }
        }

        private static void Run(IStartableBus bus)
        {
            while (true)
            {
                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.R)
                {
                    SendRegularCommand(bus);
                }

                if (key.Key == ConsoleKey.P)
                {
                    SendPreferedCommand(bus);
                }
            }
        }

        private static void SendPreferedCommand(IBus bus)
        {
            bus.Send("x-receiver-preferred", new PreferredCommand {Description = "preferred command", Extra = "wow"});
        }

        private static void SendRegularCommand(IBus bus)
        {
            bus.Send("x-receiver-regular", new RegularCommand { Description = "regular command" });
        }
    }
}
