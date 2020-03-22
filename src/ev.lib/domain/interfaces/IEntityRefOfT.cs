using System;
using System.Threading.Tasks;

namespace ev.lib.domain.interfaces
{
    public interface IEntityRef<T> : IIdEntity
        where T: IIdEntity
    {
        Task Process(Action<T> @action); 
    }
}