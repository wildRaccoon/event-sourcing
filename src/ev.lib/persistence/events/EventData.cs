using AutoMapper.Configuration.Annotations;
using ev.lib.persistence.converters;
namespace ev.lib.persistence
{
    public class EventData
    {
        public string EventId { get; set; }

        /// <summary>
        /// timestamp - unix time with miliseconds
        /// </summary>
        [ValueConverter(typeof(DateTimeToUnixTimeValueConverter))]
        public long Occured { get; set; }
        [ValueConverter(typeof(DateTimeToUnixTimeValueConverter))]
        public long Recorded { get; set; }
    }
}