using System;
using Messages.Commands;
using NServiceBus;
using NServiceBus.Persistence;

namespace Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new BusConfiguration();
            configuration.EndpointName("x-sender");
            configuration.UseTransport<AzureServiceBusTransport>().ConnectionString("Endpoint=sb://seanfeldman-test.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=VB/pEide3r1PWV094sR3SlzpcaBJtKMnctpsb4JmeU8=");
            configuration.UsePersistence<InMemoryPersistence>();
            configuration.UsePersistence<AzureStoragePersistence, StorageType.Subscriptions>();
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
            bus.Send("x-receiver-preferred-xps13", new PreferredCommand {Description = "preferred command", Extra = "wow"});
        }

        private static void SendRegularCommand(IBus bus)
        {
            bus.Send("x-receiver-regular-xps13", new RegularCommand { Description = "regular command" });
        }
    }
}
