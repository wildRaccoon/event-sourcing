using ev.lib.domain.events;
using System.Threading.Tasks;

namespace ev.lib.domain.app.services.queue
{
    public interface IQueueService
    {
        Task AddEvent<T>(T @event)
            where T: DomainEvent;
    }
}
