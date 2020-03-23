using AutoMapper;
using ev.lib.domain.core;
using ev.lib.domain.interfaces;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ev.lib.persistence.entites.domain
{
    [AutoMap(typeof(Ship))]
    public class ShipData : IIdEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string RegistrationCode { get; set; }
        public PortData Location { get; set; }
    }
}
