using ev.lib.domain.app.queries;
using System;
using System.Threading.Tasks;

namespace ev.lib.domain.interfaces
{
    public interface IEntityRef<T> : IIdEntity
        where T: class, IIdEntity, new()
    {
        IEntityRef<T> UseQuery(ISingleQuery<T> query);
        Task Process(Action<T> @action); 
    }
}