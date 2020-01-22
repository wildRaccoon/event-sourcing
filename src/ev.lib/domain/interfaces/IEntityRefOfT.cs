using System;

namespace ev.lib.domain.interfaces
{
    public interface IEntityRef<T>: IIdEntity
        where T: class
    {
        void Process(Action<T> @action); 
    }
}