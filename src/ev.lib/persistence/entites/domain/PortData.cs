using AutoMapper;
using ev.lib.domain.core;

namespace ev.lib.persistence.entites.domain
{
    [AutoMap(typeof(Port))]
    public class PortData
    {
        public string Name { get; set; }
    }
}
