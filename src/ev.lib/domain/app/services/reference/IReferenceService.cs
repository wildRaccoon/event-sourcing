using ev.lib.domain.app.queries;
using ev.lib.domain.interfaces;
using System;

namespace ev.lib.domain.app.services.reference
{
    public interface IReferenceService<T>
        where T : class, IIdEntity, new()
    {
        IEntityRef<T> GetRef(string id);
        /// <summary>
        /// find entity by query
        /// </summary>
        IEntityRef<T> GetRef(ISingleQuery<T> query);
        /// <summary>
        /// get reference for new instance
        /// </summary>
        /// <returns></returns>
        IEntityRef<T> GetRef();
    }
}
