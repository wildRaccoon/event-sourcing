using ev.lib.domain.interfaces;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Text.Json;

namespace ev.lib.persistence.services.EventGateway
{
    public class EventGatewayService : IEventGateway
    {
        ILogger<EventGatewayService> logger;

        public EventGatewayService(ILogger<EventGatewayService> logger)
        {
            this.logger = logger;
        }

        public async Task PublishAsync<T>(T t) where T : IIdEntity
        {
            logger.LogInformation($"Publish update:{t.GetType().FullName} {JsonSerializer.Serialize(t)}");
        }
    }
}
