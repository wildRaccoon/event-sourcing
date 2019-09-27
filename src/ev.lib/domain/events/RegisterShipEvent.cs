using ev.lib.domain.core;
using ev.lib.domain.interfaces;
using ev.lib.persistence.events;

namespace ev.lib.domain.events
{
    public class RegisterShipEvent : DomainEvent
    {
        RegisterShipEventData storeEvent;
        IEntityContainer entityContainer;

        public RegisterShipEvent(RegisterShipEventData registerShipEvent, IEntityContainer entityContainer)
        {
            this.entityContainer = entityContainer;
            this.storeEvent = registerShipEvent;
        }

        public override void Process()
        {
            var ship = entityContainer.Create<Ship>();
            var port = entityContainer.Get<Port>(storeEvent.Port);

            ship.RegisterShip(storeEvent.Name,storeEvent.Port,port);
            entityContainer.Update(ship);
        }
    }
}