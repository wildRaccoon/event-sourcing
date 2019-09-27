using System;
using System.Collections.Generic;
using System.Text;

namespace ev.lib.persistence.entites
{
    public class StoreEntity<T>
        where T : class
    {
        public string Id { get; set; }
        public T Entity { get; set; }
    }
}
