namespace ev.lib.domain.core
{
    public class Port
    {
        public string Id { get; set; }
        
        public string Name {get; set;}

        public string InternationalCode { get; set; }

        public static Port AT_SEA { get => new Port() { Name = "At Sea", InternationalCode = "OVERSEAS" }; }

        public Port()
        { 
        }
    }
}