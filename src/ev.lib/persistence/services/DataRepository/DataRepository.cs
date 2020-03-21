using System.Threading.Tasks;
using AutoMapper;
using ev.lib.domain.interfaces;
using MongoDB.Driver;

namespace ev.lib.persistence.services.DataRepository
{
    public class DataRepository<TApp, TData> : IDataRepository<TApp, TData>
        where TApp : class, IIdEntity
        where TData : class, IIdEntity
    {
        private IMapper mapper;
        private IMongoCollection<TData> collection;
        public DataRepository(IMongoDatabase client)
        {
            this.collection = client.GetCollection<TData>(typeof(TData).FullName);
            this.mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<TApp, TData>()));
        }

        public void Add(TApp t)
        {
            var data = mapper.Map<TData>(t);
            collection.InsertOne(data);
        }

        public async Task AddAsync(TApp t)
        {
            var data = mapper.Map<TData>(t);
            await collection.InsertOneAsync(data);
        }

        public TApp Get(string id)
        {
            var data = collection.Find<TData>(f => f.Id == id);
            return mapper.Map<TApp>(data);
        }

        public async Task<TApp> GetAsync(string id)
        {
            var data = await collection.FindAsync<TData>(f => f.Id == id);
            return mapper.Map<TApp>(data);
        }

        public void Remove(TApp t)
        {
            collection.DeleteOne(f => f.Id == t.Id);
        }

        public async Task RemoveAsync(TApp t)
        {
            await collection.DeleteOneAsync(f => f.Id == t.Id);
        }

        public void Update(TApp t)
        {
            var data = mapper.Map<TData>(t);
            collection.ReplaceOne(f => f.Id == t.Id, data);
        }

        public async Task UpdateAsync(TApp t)
        {
            var data = mapper.Map<TData>(t);
            await collection.ReplaceOneAsync(f => f.Id == t.Id, data);
        }
    }
}