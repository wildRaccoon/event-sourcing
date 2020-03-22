using ev.lib.domain.interfaces;
using System;
using System.Threading.Tasks;

namespace ev.lib.domain.app.services.reference
{
    public class EntityRefById<T> : IEntityRef<T>
            where T : class, IIdEntity, new() 
    {
        readonly IRepository<T> repository;
        public EntityRefById(IRepository<T> repository)
        {
            this.repository = repository;
        }

        public string Id { get; private set; }

        public IEntityRef<T> UseId(string id)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                throw new Exception($"Id already set.");
            }

            Id = id;

            return this;
        }

        public async Task Process(Action<T> action)
        {
            var item = await repository.GetAsync(Id);
            action(item);
            await repository.UpdateAsync(item);
        }
    }
}
