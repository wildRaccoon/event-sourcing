using ev.lib.domain.core;
using ev.lib.domain.interfaces;
using System;
using System.Threading.Tasks;

namespace ev.lib.domain.events
{
    public class RegisterShipEvent : DomainEvent
    {
        public IEntityRef<Ship> Ship { private set; get; }
        public Port Port { private set; get; }
        public string Name { private set; get; }
        public string Code { private set; get; }

        public RegisterShipEvent(DateTime occured, string eventId, IEntityRef<Ship> ship, Port port, string name, string code) : base(occured, eventId)
        {
            this.Ship = ship;
            this.Port = port;
            this.Name = name;
            this.Code = code;
        }

        public override async Task Process()
        {
            await Ship.Process(s => s.RegisterShip(this));
        }
    }
}