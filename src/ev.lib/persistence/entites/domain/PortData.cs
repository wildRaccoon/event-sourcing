using AutoMapper;
using ev.lib.domain.core;
using ev.lib.domain.interfaces;

namespace ev.lib.persistence.entites.domain
{
    [AutoMap(typeof(Port))]
    public class PortData : IIdEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string IntlCode { get; set; }
    }
}
