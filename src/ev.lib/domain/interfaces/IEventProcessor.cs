using ev.lib.domain.events;
using System.Threading.Tasks;

namespace ev.lib.domain.interfaces
{
    public interface IEventProcessor<T> 
        where T: class
    {
        Task<T> ProcessAsync(DomainEvent @event);
    }
}
