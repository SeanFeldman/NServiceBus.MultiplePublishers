using System;
using NServiceBus;
using NServiceBus.Persistence;

namespace Receiver.Preferred
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new BusConfiguration();
            configuration.EndpointName("x-receiver-preferred");
            configuration.UseTransport<AzureServiceBusTransport>().ConnectionString("Endpoint=sb://seanfeldman-test.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=VB/pEide3r1PWV094sR3SlzpcaBJtKMnctpsb4JmeU8=");
            configuration.UsePersistence<InMemoryPersistence>();
            configuration.UsePersistence<AzureStoragePersistence, StorageType.Subscriptions>();
            configuration.UseSerialization<JsonSerializer>();
            configuration.EnableInstallers();
            using (var bus = Bus.Create(configuration))
            {
                bus.Start();
                Console.WriteLine("\r\nPress enter key to stop program\r\n");
                Console.Read();
            }

        }
    }
}
