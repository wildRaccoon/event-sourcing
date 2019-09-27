namespace ev.lib.persistence
{
    public class RegisterShipStoreEvent : StoreEvent
    {
        public string RegistrationCode {get; set;}

        public string Name {get; set;}

        public string Port {get; set;}

        public RegisterShipStoreEvent()
        {
        }
    }
}