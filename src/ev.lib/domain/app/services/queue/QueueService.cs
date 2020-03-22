using ev.lib.domain.events;
using System.Threading.Tasks;
using System.Threading.Channels;
using Microsoft.Extensions.Logging;

namespace ev.lib.domain.app.services.queue
{
    public class QueueService : IQueueService
    {
        readonly Channel<DomainEvent> channel = Channel.CreateUnbounded<DomainEvent>(new UnboundedChannelOptions()
        {
            SingleReader = true,
            SingleWriter = false,
            AllowSynchronousContinuations = false
        });

        Task readTask;
        ILogger<QueueService> logger;

        public QueueService(ILogger<QueueService> logger)
        {
            readTask = Consume(channel.Reader);
            this.logger = logger;
        }

        private async Task Consume(ChannelReader<DomainEvent> reader)
        {
            while (await reader.WaitToReadAsync())
            {
                if (reader.TryRead(out DomainEvent @event))
                {
                    logger.LogInformation($"Process Event: {@event.GetType().FullName} {@event.Id} {@event.Occured}");
                    await @event.Process();
                }
            }
        }

        public async Task AddEvent<T>(T @event) where T : DomainEvent
        {
            logger.LogInformation($"Add Event: {@event.GetType().FullName} {@event.Id} {@event.Occured}");
            await channel.Writer.WriteAsync(@event);
        }
    }
}
