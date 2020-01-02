using ev.lib.domain.interfaces;

namespace ev.lib.persistence.services.DataRepository
{
    public interface IDataRepository<TApp, TData> : IRepository<TApp>
        where TApp : class, IIdEntity
        where TData : class, IIdEntity
    {
         
    }
}