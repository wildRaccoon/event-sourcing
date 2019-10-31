using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ev.lib.domain.interfaces
{
    public interface IRepository
    {
        Task AddAsync<T>(T t) where T: class;
        Task UpdateAsync<T>(T t) where T : class;
        Task RemoveAsync<T>(T t) where T : class;
        Task<T> GetAsync<T>(string id) where T : class;
        Task<List<T>> QueryAsync<T>(Func<T, bool> query) where T : class;
    }
}
