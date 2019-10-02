using System;

namespace ev.lib.domain.events
{
    public abstract class DomainEvent
    {
        public DateTime Occured { private set; get; }
        public DateTime Recorded { private set; get; }

        public DomainEvent(DateTime occured)
        {
            Occured = occured;
            Recorded = DateTime.Now;
        }

        public abstract void Process();
    }
}