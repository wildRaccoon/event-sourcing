using ev.lib.domain.interfaces;
using System;
using Microsoft.Extensions.DependencyInjection;
using ev.lib.domain.app.queries;

namespace ev.lib.domain.app.services.reference
{
    public class ReferenceService<T> : IReferenceService<T>
        where T : class, IIdEntity, new()
    {
        IServiceScope serviceScope;
        IServiceProvider serviceProvider;
        public ReferenceService(IServiceProvider serviceProvider)
        {
            this.serviceScope = serviceProvider.CreateScope();
            this.serviceProvider = serviceScope.ServiceProvider;
        }

        public IEntityRef<T> GetRef(string id)
        {
            var queryById = serviceProvider.GetService<ISingleQueryById<T>>();
            return serviceProvider.GetService<EntityRef<T>>().UseQuery(queryById);
        }

        public IEntityRef<T> GetRef(ISingleQuery<T> query)
        {
            return serviceProvider.GetService<EntityRef<T>>().UseQuery(query);
        }

        public IEntityRef<T> GetRef()
        {
            var queryAquireNew = serviceProvider.GetService<ISingleQueryAquireNew<T>>();
            return serviceProvider.GetService<EntityRef<T>>().UseQuery(queryAquireNew);
        }
    }
}