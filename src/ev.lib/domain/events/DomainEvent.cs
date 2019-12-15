using System;

namespace ev.lib.domain.events
{
    public abstract class DomainEvent
    {
        public string EventId { private set; get; }
        public DateTime Occured { private set; get; }
        public DateTime Recorded { private set; get; }

        public DomainEvent(DateTime occured, string eventId)
        {
            EventId = eventId;
            Occured = occured;
            Recorded = DateTime.Now;
        }

        public abstract void Process();
    }
}