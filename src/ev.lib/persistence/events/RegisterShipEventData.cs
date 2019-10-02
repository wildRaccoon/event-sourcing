using ev.lib.persistence.entites.domain;

namespace ev.lib.persistence.events
{
    public class RegisterShipEventData : ShipEventData
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public PortData Port { get; set; }
        public RegisterShipEventData()
        {
        }
    }
}