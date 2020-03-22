using ev.lib.domain.interfaces;
using MongoDB.Driver;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ev.lib.persistence.services.DataRepository
{
    public interface IDataRepository<TApp, TData> : IRepository<TApp>
        where TApp : class, IIdEntity
        where TData : class, IIdEntity
    {
        Task<TApp> QuerySingle(Expression<Func<TData, bool>> filter);
    }
}