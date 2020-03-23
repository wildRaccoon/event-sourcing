using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using ev.lib.domain.interfaces;
using MongoDB.Driver;

namespace ev.lib.persistence.services.DataRepository
{
    public class DataRepositoryService<TApp, TData> : IDataRepository<TApp, TData>
        where TApp : class, IIdEntity
        where TData : class, IIdEntity
    {
        private IMapper mapper;
        private IMongoCollection<TData> collection;
        public DataRepositoryService(IMongoDatabase client, IMapper mapper)
        {
            this.collection = client.GetCollection<TData>(typeof(TData).FullName);
            this.mapper = mapper;
        }

        public async Task AddAsync(TApp t)
        {
            var data = mapper.Map<TData>(t);
            await collection.InsertOneAsync(data);
            t.Id = data.Id;
        }

        public async Task<TApp> GetAsync(string id)
        {
            var data = await collection.FindAsync<TData>(f => f.Id == id);
            return mapper.Map<TApp>(data);
        }

        public async Task RemoveAsync(TApp t)
        {
            await collection.DeleteOneAsync(f => f.Id == t.Id);
        }

        public async Task UpdateAsync(TApp t)
        {
            var data = mapper.Map<TData>(t);
            await collection.ReplaceOneAsync(f => f.Id == t.Id, data);
        }

        public async Task<TApp> QuerySingle(Expression<Func<TData, bool>> filter)
        {
            var result = await collection.FindAsync<TData>(filter);

            var data = result.Single();
            return mapper.Map<TApp>(data);
        }
    }
}