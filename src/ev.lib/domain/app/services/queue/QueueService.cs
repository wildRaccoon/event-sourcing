using ev.lib.domain.events;
using System.Threading.Tasks;
using System.Threading.Channels;
using System;

namespace ev.lib.domain.app.services.queue
{
    public class QueueService : IQueueService
    {
        Channel<DomainEvent> channel = Channel.CreateUnbounded<DomainEvent>(new UnboundedChannelOptions()
        {
            SingleReader = true,
            SingleWriter = false,
            AllowSynchronousContinuations = false
        });

        Task readTask;

        public QueueService()
        {
            readTask = Consume(channel.Reader);
        }

        private async Task Consume(ChannelReader<DomainEvent> reader)
        {
            while (await reader.WaitToReadAsync())
            {
                if (reader.TryRead(out DomainEvent @event))
                {
                    Console.WriteLine($"{@event.Id} {@event.Occured}");
                }
            }
        }

        public async Task AddEvent<T>(T @event) where T : DomainEvent
        {
            await channel.Writer.WriteAsync(@event);
        }
    }
}
