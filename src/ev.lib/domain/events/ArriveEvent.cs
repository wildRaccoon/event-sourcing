using ev.lib.domain.core;
using System;

namespace ev.lib.domain.events
{
    public class ArriveEvent : DomainEvent
    {
        public Ship ship { private set; get; }
        public Port port { private set; get; }

        public ArriveEvent(DateTime occured, Ship ship, Port port) : base(occured)
        {
            this.ship = ship;
            this.port = port;
        }

        public override void Process()
        {
            ship.Arrive(this);
        }
    }
}
