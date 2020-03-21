using ev.lib.domain.core;
using System.Threading.Tasks;

namespace ev.lib.domain.app.queries
{
    public interface ISingleQueryPortByIntCode : ISingleQuery<Port>
    {
        ISingleQueryPortByIntCode UseIntCode(string intCode);
    }
}
