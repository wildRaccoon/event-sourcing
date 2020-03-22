using ev.lib.domain.app.queries;
using ev.lib.domain.interfaces;
using System;
using System.Threading.Tasks;

namespace ev.lib.persistence.queries
{
    public class SingleQueryById<T> : ISingleQueryById<T>
            where T : class, IIdEntity, new()
    {
        IRepository<T> repository;
        string id;
        public SingleQueryById(IRepository<T> repository)
        {
            this.repository = repository;
        }

        public void UseId(string id)
        {
            if (!string.IsNullOrEmpty(this.id))
            {
                throw new Exception($"Id value already setted up.");
            }

            this.id = id;
        }

        public async Task<T> ExecuteAsync()
        {
            return await repository.GetAsync(id);
        }
    }
}
