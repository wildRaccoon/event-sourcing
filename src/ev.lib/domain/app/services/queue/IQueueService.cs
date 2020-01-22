using ev.lib.domain.events;

namespace ev.lib.domain.app.services.queue
{
    public interface IQueueService
    {
        void AddEvent<T>(T @event)
            where T: DomainEvent;
    }
}
