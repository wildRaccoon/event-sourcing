using System.Threading.Tasks;
using ev.lib.domain.events;
using ev.lib.domain.interfaces;

namespace ev.lib.domain.app
{
    public class EventProcessor : IEventProcessor
    {
        private IRepository _repository;
        private IEventGateway _eventGateway;
        
        public EventProcessor(IRepository repository, IEventGateway eventGateway)
        {
            this._repository = repository;
            this._eventGateway = eventGateway;
        }
        
        public async Task<T> ProcessAsync<T>(T @event)
            where  T: DomainEvent
        {
            //save event before process it
            await _repository.AddAsync(@event);
            
            @event.Process();

            await _eventGateway.PublishAsync(@event);

            return @event;
        }
    }
}