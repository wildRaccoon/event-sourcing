using AutoMapper.Configuration.Annotations;
using ev.lib.domain.interfaces;
using ev.lib.persistence.converters;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ev.lib.persistence
{
    public class EventData : IIdEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// timestamp - unix time with miliseconds
        /// </summary>
        [ValueConverter(typeof(DateTimeToUnixTimeValueConverter))]
        public long Occured { get; set; }
        [ValueConverter(typeof(DateTimeToUnixTimeValueConverter))]
        public long Recorded { get; set; }
    }
}