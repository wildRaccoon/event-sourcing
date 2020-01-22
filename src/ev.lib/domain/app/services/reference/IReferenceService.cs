using ev.lib.domain.interfaces;
using System;

namespace ev.lib.domain.app.services.reference
{
    public interface IReferenceService<T>
        where T : IIdEntity
    {
        IEntityRef<T> GetRef(string id);
        IEntityRef<T> GetRef<TOut>(Func<T, TOut> prop, TOut val);
        /// <summary>
        /// get reference for new instance
        /// </summary>
        /// <returns></returns>
        IEntityRef<T> GetRef();
    }
}
