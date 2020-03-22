using System;
using System.Threading.Tasks;
using ev.lib.domain.interfaces;

namespace ev.lib.domain.events
{
    public abstract class DomainEvent : IIdEntity
    {
        public string Id { private set; get; }
        public DateTime Occured { private set; get; }
        public DateTime Recorded { private set; get; }

        public DomainEvent(DateTime occured, string eventId)
        {
            Id = eventId;
            Occured = occured;
            Recorded = DateTime.Now;
        }

        public abstract Task Process();
    }
}