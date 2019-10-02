using ev.lib.domain.core;
using System;

namespace ev.lib.domain.events
{
    public class DepartureEvent : DomainEvent
    {
        public Ship ship { private set; get; }
        public Port port { private set; get; }

        public DepartureEvent(DateTime occured,Ship ship, Port port) : base(occured)
        {
            this.ship = ship;
            this.port = port;
        }

        public override void Process()
        {
            ship.Departure(this);
        }
    }
}
