using ev.lib.domain.app.queries;
using ev.lib.domain.interfaces;
using System.Threading.Tasks;

namespace ev.lib.persistence.queries
{
    public class SingleQueryAquireNew<T> : ISingleQueryAquireNew<T>
        where T : class, IIdEntity, new()
    {
        IRepository<T> repository;
        public SingleQueryAquireNew(IRepository<T> repository)
        {
            this.repository = repository;
        }

        public async Task<T> ExecuteAsync()
        {
            var t = new T();

            //Add operation will fill id value
            await repository.AddAsync(t);
            
            return t;
        }
    }
}
