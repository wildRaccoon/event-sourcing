using ev.lib.domain.core;
using System.Threading.Tasks;

namespace ev.lib.domain.app.queries
{
    public interface IQueryPortByIntCode
    {
        Task<Port> Execute(string intCode);
    }
}
