using AutoMapper;
using ev.lib.domain.events;

namespace ev.lib.persistence.events
{
    [AutoMap(typeof(DepartureEvent), ReverseMap = true)]
    public class DepartureEventData : ShipEventData
    {
        public string PortIntlCode { get; set; }
    }
}