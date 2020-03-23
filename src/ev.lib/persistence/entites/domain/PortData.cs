using AutoMapper;
using ev.lib.domain.core;
using ev.lib.domain.interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ev.lib.persistence.entites.domain
{
    [AutoMap(typeof(Port))]
    public class PortData : IIdEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }
        public string IntlCode { get; set; }
    }
}
