using ev.lib.domain.core;
using System;

namespace ev.lib.domain.events
{
    public class DepartureEvent : DomainEvent
    {
        public Ship Ship { private set; get; }
        public Port Port { private set; get; }

        public DepartureEvent(DateTime occured, Ship ship, Port port) : base(occured)
        {
            this.Ship = ship;
            this.Port = port;
        }

        public override void Process()
        {
            Ship.Departure(this);
        }
    }
}
