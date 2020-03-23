using ev.lib.domain.events;
using ev.lib.domain.interfaces;
using System;

namespace ev.lib.domain.core
{
    public class Ship : IIdEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string RegistrationCode { get; set; }
        public Port Location { get; set; }

        public Ship()
        {

        }

        public Ship(string id)
        {
            Id = id;
        }

        public Ship(string id, string name, string regcode, Port loc) : this(id)
        {
            Name = name;
            RegistrationCode = regcode;
            Location = loc;
        }

        public void RegisterShip(RegisterShipEvent @event)
        {
            if (!string.IsNullOrEmpty(RegistrationCode))
            {
                throw new Exception($"Ship already registered: {Name}: {RegistrationCode} : {Location.Name}");
            }

            if (@event.Port == null || @event.Port.Name == Port.AT_SEA.Name)
            {
                throw new Exception($"Can't register ship At Sea location: {@event.Name}: {@event.Name} : {@event.Port?.Name ?? "port not set"}");
            }

            Name = @event.Name;
            RegistrationCode = @event.Code;
            Location = @event.Port;
        }

        public void Departure(DepartureEvent @event)
        {
            Location = Port.AT_SEA;
        }

        public void Arrive(ArriveEvent @event)
        {
            Location = @event.Port;
        }
    }
}