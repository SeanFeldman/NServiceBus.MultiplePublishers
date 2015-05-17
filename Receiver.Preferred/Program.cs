using System;
using NServiceBus;

namespace Receiver.Preferred
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new BusConfiguration();
            configuration.EndpointName("x-receiver-preferred");
            configuration.UseTransport<AzureServiceBusTransport>().ConnectionString("Endpoint=sb://seanfeldman-test.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=");
            configuration.UsePersistence<InMemoryPersistence>();
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
