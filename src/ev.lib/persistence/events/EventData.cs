namespace ev.lib.persistence
{
    public class EventData
    {
        public string EventId { get; set; }

        /// <summary>
        /// timestamp - unix time with miliseconds
        /// </summary>
        public long Occured { get; set; }

        public long Recorded { get; set; }
    }
}