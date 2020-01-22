using ev.lib.domain.core;
using ev.lib.domain.interfaces;
using System;

namespace ev.lib.domain.events
{
    public class DepartureEvent : DomainEvent
    {
        public IEntityRef<Ship> Ship { private set; get; }
        public Port Port { private set; get; }

        public DepartureEvent(DateTime occured, string eventId, IEntityRef<Ship> ship, Port port) : base(occured, eventId)
        {
            this.Ship = ship;
            this.Port = port;
        }

        public override void Process()
        {
            Ship.Process(s => s.Departure(this));
        }
    }
}
