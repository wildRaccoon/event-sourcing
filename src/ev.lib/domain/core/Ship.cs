using System;

namespace ev.lib.domain.core
{
    public class Ship
    {
        public string Name {get; private set;}
        public string RegistrationCode { get; private set;}
        public Port Location {get; private set;}

        public Ship()
        {

        }

        public void RegisterShip(string name, string code, Port location)
        { 
            if(!string.IsNullOrEmpty(RegistrationCode))
            {
                throw new Exception($"Ship already registered: {name}: {code} : {location.Name}");
            }

            if(location == null || location.Name == Port.AT_SEA.Name)
            {
                throw new Exception($"Can'r register ship At Sea location: {name}: {code} : {location?.Name ?? "port not set"}");
            }

            Name = name;
            RegistrationCode = code;
            Location = location;
        }
    }
}