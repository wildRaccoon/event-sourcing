using System.Threading.Tasks;

namespace ev.lib.domain.interfaces
{
    public interface IEventGateway
    {
        Task PublishAsync<T>(T t) where T: IIdEntity;
    }
}