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
            return serviceProvider.GetService<EntityRefById<T>>().UseId(id);
        }

        public IEntityRef<T> GetRef(ISingleQuery<T> query)
        {
            return serviceProvider.GetService<EntityRefByQuery<T>>().UseQuery(query);
        }

        public IEntityRef<T> GetRef()
        {
            return serviceProvider.GetService<EntityRefNew<T>>();
        }
    }
}