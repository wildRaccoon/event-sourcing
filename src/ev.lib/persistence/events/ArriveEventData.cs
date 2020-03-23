using AutoMapper;
using ev.lib.domain.events;

namespace ev.lib.persistence.events
{
    [AutoMap(typeof(ArriveEvent), ReverseMap = true)]
    public class ArriveEventData : ShipEventData
    {
        public string PortIntlCode { get; set; }
    }
}