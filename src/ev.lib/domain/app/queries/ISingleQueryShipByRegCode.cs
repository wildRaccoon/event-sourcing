using ev.lib.domain.core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ev.lib.domain.app.queries
{
    public interface ISingleQueryShipByRegCode : ISingleQuery<Ship>
    {
        ISingleQueryShipByRegCode UseRegCode(string regCode);
    }
}
