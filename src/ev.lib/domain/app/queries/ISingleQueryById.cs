using ev.lib.domain.interfaces;
namespace ev.lib.domain.app.queries
{
    public interface ISingleQueryById<T> : ISingleQuery<T>
        where T : class, IIdEntity, new()
    {
        void UseId(string id);
    }
}
