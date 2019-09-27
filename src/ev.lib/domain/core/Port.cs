namespace ev.lib.domain.core
{
    public class Port
    {
        public string Name {get; private set;}

        public static Port AT_SEA { get => new Port("At Sea"); }

        public Port(string name)
        {
            Name = name;
        }
    }
}