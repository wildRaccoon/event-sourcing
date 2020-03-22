using ev.lib.domain.interfaces;
using System.Threading.Tasks;

namespace ev.lib.domain.app.queries
{
    public interface ISingleQuery<T>
        where T : class, IIdEntity, new()
    {
        Task<T> ExecuteAsync();
    }
}
