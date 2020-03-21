using ev.lib.domain.interfaces;
using System;

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

        public void Process(Action<T> action)
        {
            var item = new T();
            action(item);
            repository.Add(item);
        }
    }
}
