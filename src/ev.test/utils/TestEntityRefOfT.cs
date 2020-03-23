using System;
using System.Threading.Tasks;
using ev.lib.domain.app.queries;
using ev.lib.domain.interfaces;

namespace ev.test.utils
{
    public class TestEntityRef<T> : IEntityRef<T>
        where T : class, IIdEntity, new()
    {
        public TestEntityRef(string id,T t)
        {
            Id = id;
            entity = t;
        }

        public string Id { get; set; }

        private T entity { get; set; }

        public async Task Process(Action<T> action)
        {
            action.Invoke(entity);
        }

        public IEntityRef<T> UseQuery(ISingleQuery<T> query)
        {
            throw new NotImplementedException();
        }
    }
}