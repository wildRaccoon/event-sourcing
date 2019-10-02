using System;

namespace ev.lib.domain.events
{
    public abstract class DomainEvent
    {
        public long Occured { private set; get; }
        public long Recorded { private set; get; }
        public abstract void Process();
    }
}