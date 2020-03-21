using System.Threading.Tasks;

namespace ev.lib.domain.interfaces
{
    public interface IRepository<T>
        where T : class, IIdEntity
    {
        void Add(T t);
        void Update(T t);
        void Remove(T t);
        T Get(string id);

        Task AddAsync(T t);
        Task UpdateAsync(T t);
        Task RemoveAsync(T t);
        Task<T> GetAsync(string id);
    }
}
