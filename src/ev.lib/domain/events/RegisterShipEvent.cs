using ev.lib.domain.core;
using System;

namespace ev.lib.domain.events
{
    public class RegisterShipEvent : DomainEvent
    {
        public Ship ship { private set; get; }
        public Port port { private set; get; }
        public string name { private set; get; }
        public string code { private set; get; }

        public RegisterShipEvent(DateTime occured, Ship ship, Port port, string name, string code) : base(occured)
        {
            this.ship = ship;
            this.port = port;
            this.name = name;
            this.code = code;
        }

        public override void Process()
        {
            ship.RegisterShip(this);
        }
    }
}