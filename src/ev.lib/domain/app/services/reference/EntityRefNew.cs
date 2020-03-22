using ev.lib.domain.interfaces;
using System;
using System.Threading.Tasks;

namespace ev.lib.domain.app.services.reference
{
    public class EntityRefNew<T> : IEntityRef<T>
            where T : class, IIdEntity, new()
    {
        readonly IRepository<T> repository;
        public EntityRefNew(IRepository<T> repository)
        {
            this.repository = repository;
        }

        public string Id { get; private set; }

        public async Task Process(Action<T> action)
        {
            var item = new T();
            
            await repository.AddAsync(item);
            Id = item.Id;

            action(item);
            
            await repository.UpdateAsync(item);
        }
    }
}
