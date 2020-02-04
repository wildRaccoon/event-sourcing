using ev.lib.domain.interfaces;

namespace ev.lib.domain.app.services.reference
{
    public class ReferenceService<T> : IReferenceService<T>
        where T : IIdEntity
    {
        public ReferenceService()
        {
        }

        public IEntityRef<T> GetRef(string id)
        {
            throw new System.NotImplementedException();
        }

        public IEntityRef<T> GetRef<TOut>(System.Func<T, TOut> prop, TOut val)
        {
            throw new System.NotImplementedException();
        }

        public IEntityRef<T> GetRef()
        {
            throw new System.NotImplementedException();
        }
    }
}