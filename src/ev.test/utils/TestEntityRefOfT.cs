using System;
using ev.lib.domain.interfaces;

namespace ev.test.utils
{
    public class TestEntityRef<T> : IEntityRef<T>
        where T : class
    {
        public TestEntityRef(string id,T t)
        {
            Id = id;
            entity = t;
        }

        public string Id { get; private set; }

        private T entity { get; set; }

        public void Process(Action<T> action)
        {
            action.Invoke(entity);
        }
    }
}