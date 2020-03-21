using ev.lib.domain.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ev.lib.domain.app.queries
{
    public interface ISingleQuery<T>
        where T : class, IIdEntity, new()
    {
        T Execute();
    }
}
