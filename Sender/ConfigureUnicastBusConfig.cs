using NServiceBus.Config;
using NServiceBus.Config.ConfigurationSource;

namespace Sender
{
    public class ConfigureUnicastBusConfig : IProvideConfiguration<UnicastBusConfig>
    {
        public UnicastBusConfig GetConfiguration()
        {
            return new UnicastBusConfig
            {
                MessageEndpointMappings = new MessageEndpointMappingCollection
                {
                    new MessageEndpointMapping
                    {
                        Endpoint = "x-receiver-regular",
                        Messages = "Messages.Events.NotifyEvent, Messages"
                    },
                    new MessageEndpointMapping
                    {
                        Endpoint = "x-receiver-preferred",
                        AssemblyName = "Messages",
                        Namespace = "Messages.Events"
                    }
                }
            };
        }
    }
}