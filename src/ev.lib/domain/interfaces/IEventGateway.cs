using System.Threading.Tasks;
using ev.lib.domain.events;

namespace ev.lib.domain.interfaces
{
    public interface IEventGateway
    {
        Task PublishAsync<T>(T t) where T: DomainEvent;
    }
}