using AutoMapper;
using ev.lib.domain.events;

namespace ev.lib.persistence.events
{
    [AutoMap(typeof(RegisterShipEvent), ReverseMap = true)]
    public class RegisterShipEventData : ShipEventData
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string PortIntlCode { get; set; }
    }
}