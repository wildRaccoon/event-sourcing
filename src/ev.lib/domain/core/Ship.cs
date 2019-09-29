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

        public void RegisterShip(string name, string code, Port location)
        { 
            if(!string.IsNullOrEmpty(RegistrationCode))
            {
                throw new Exception($"Ship already registered: {name}: {code} : {location.Name}");
            }

            if(location == null || location.Name == Port.AT_SEA.Name)
            {
                throw new Exception($"Can't register ship At Sea location: {name}: {code} : {location?.Name ?? "port not set"}");
            }

            Name = name;
            RegistrationCode = code;
            Location = location;
        }
    }
}