using ev.lib.domain.core;

namespace ev.lib.domain.events
{
    public class RegisterShipEvent : DomainEvent
    {
        Ship ship;
        Port port;
        string shipName;
        string shipRegCode;

        public RegisterShipEvent(Ship ship, Port port, string shipName,string shipRegCode)
        {
            this.ship = ship;
            this.port = port;
            this.shipName = shipName;
            this.shipRegCode = shipRegCode;
        }

        public override void Process()
        {
            ship.RegisterShip(shipName, shipRegCode, port);
        }
    }
}