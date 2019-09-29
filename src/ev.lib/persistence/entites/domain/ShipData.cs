using AutoMapper;
using ev.lib.domain.core;

namespace ev.lib.persistence.entites.domain
{
    [AutoMap(typeof(Ship))]
    public class ShipData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string RegistrationCode { get; set; }
        public PortData Location { get; set; }
    }
}
