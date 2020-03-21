using System;

namespace ev.lib.domain.interfaces
{
    public interface IEntityRef<T>
        where T: IIdEntity
    {
        void Process(Action<T> @action); 
    }
}