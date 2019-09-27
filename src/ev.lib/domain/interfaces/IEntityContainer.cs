using System;
using System.Collections.Generic;
using System.Text;

namespace ev.lib.domain.interfaces
{
    public interface IEntityContainer
    {
        T Create<T>() where T : class, new();
        void Update<T>(T item) where T: class;
        T Get<T>(string id) where T : class;
    }
}
