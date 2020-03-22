using ev.lib.domain.core;

namespace ev.lib.domain.app.queries
{
    public interface ISingleQueryShipByRegCode : ISingleQuery<Ship>
    {
        ISingleQueryShipByRegCode UseRegCode(string regCode);
    }
}
