using ev.lib.domain.events;
using System.Threading.Tasks;

namespace ev.lib.domain.interfaces
{
    public interface IEventProcessor
    {
        Task<T> ProcessAsync<T>(T @event) where T: DomainEvent;
    }
}
