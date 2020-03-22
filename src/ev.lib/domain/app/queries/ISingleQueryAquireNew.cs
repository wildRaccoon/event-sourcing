using ev.lib.domain.interfaces;

namespace ev.lib.domain.app.queries
{
    public interface ISingleQueryAquireNew<T> : ISingleQuery<T>
        where T : class, IIdEntity, new()
    {
    }
}
