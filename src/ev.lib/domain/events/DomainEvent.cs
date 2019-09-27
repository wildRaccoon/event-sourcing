namespace ev.lib.domain.events
{
    public abstract class DomainEvent
    {
        public long UTCreated;
        public long UTProcessed;
        public abstract void Process();
    }
}