namespace ev.lib.persistence.events
{
    public class RegisterShipEventData : EventData
    {
        public string RegistrationCode {get; set;}

        public string Name {get; set;}

        public string Port {get; set;}

        public RegisterShipEventData()
        {
        }
    }
}