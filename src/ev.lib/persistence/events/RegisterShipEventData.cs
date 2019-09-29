namespace ev.lib.persistence.events
{
    public class RegisterShipEventData : ShipEventData
    {
        public string ShipRegCode {get; set;}
        public string ShipName {get; set;}
        public string PortInternationalCode { get; set; }
        public RegisterShipEventData()
        {
        }
    }
}