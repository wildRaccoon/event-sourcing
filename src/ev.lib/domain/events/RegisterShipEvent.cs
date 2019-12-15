using ev.lib.domain.core;
using System;

namespace ev.lib.domain.events
{
    public class RegisterShipEvent : DomainEvent
    {
        public Ship Ship { private set; get; }
        public Port Port { private set; get; }
        public string Name { private set; get; }
        public string Code { private set; get; }

        public RegisterShipEvent(DateTime occured, string eventId, Ship ship, Port port, string name, string code) : base(occured, eventId)
        {
            this.Ship = ship;
            this.Port = port;
            this.Name = name;
            this.Code = code;
        }

        public override void Process()
        {
            Ship.RegisterShip(this);
        }
    }
}