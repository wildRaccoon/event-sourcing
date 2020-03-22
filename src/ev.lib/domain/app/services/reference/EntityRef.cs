using ev.lib.domain.app.queries;
using ev.lib.domain.interfaces;
using System;
using System.Threading.Tasks;

namespace ev.lib.domain.app.services.reference
{
    public class EntityRef<T> : IEntityRef<T>
            where T : class, IIdEntity, new()
    {
        readonly IRepository<T> repository;
        ISingleQuery<T> query;
        IEventGateway eventGateway;
        public EntityRef(IRepository<T> repository, IEventGateway eventGateway)
        {
            this.repository = repository;
            this.eventGateway = eventGateway;
        }

        public string Id { get; private set; }

        public IEntityRef<T> UseQuery(ISingleQuery<T> query)
        {
            if (this.query != null)
            {
                throw new Exception($"Query already set.");
            }

            this.query = query;

            return this;
        }

        public async Task Process(Action<T> action)
        {
            var item = await query.ExecuteAsync();
            Id = item.Id;
            action(item);
            await repository.UpdateAsync(item);
            await eventGateway.PublishAsync(item);
        }
    }
}
