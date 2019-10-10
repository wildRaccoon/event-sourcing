using AutoMapper;
using ev.lib.domain.core;
using ev.lib.persistence.entites.domain;
using Xunit;

namespace ev.test.persistence.entites.domain
{
    public class PortDataTests
    {
        [Fact(DisplayName = "PortData:AutoMapper")]
        public void PortDataMap()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(typeof(PortData).Assembly));
            var mapper = new Mapper(configuration);

            var port = new Port()
            {
                Id = "port id",
                IntlCode = "port intl code",
                Name = "port name"
            };
            var portData = mapper.Map<PortData>(port);

            Assert.Equal(port.Id, portData.Id);
            Assert.Equal(port.IntlCode, portData.IntlCode);
            Assert.Equal(port.Name, portData.Name);
        }
    }
}
