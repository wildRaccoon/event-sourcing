using ev.lib.domain.events;
using System;

namespace ev.lib.domain.core
{
    public class Ship
    {
        public string Id { get; set; }
        public string Name {get; set;}
        public string RegistrationCode { get; set;}
        public Port Location {get; set;}

        public Ship()
        {

        }

        public void RegisterShip(RegisterShipEvent @event)
        { 
            if(!string.IsNullOrEmpty(RegistrationCode))
            {
                throw new Exception($"Ship already registered: {Name}: {RegistrationCode} : {Location.Name}");
            }

            if(@event.port == null || @event.port.Name == Port.AT_SEA.Name)
            {
                throw new Exception($"Can't register ship At Sea location: {@event.name}: {@event.name} : {@event.port?.Name ?? "port not set"}");
            }

            Name = @event.name;
            RegistrationCode = @event.code;
            Location = @event.port;
        }
    }
}