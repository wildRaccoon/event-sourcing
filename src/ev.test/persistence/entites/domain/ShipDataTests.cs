using AutoMapper;
using ev.lib.domain.core;
using ev.lib.persistence.entites.domain;
using Xunit;

namespace ev.test.persistence.entites.domain
{
    public class ShipDataTests
    {
        [Fact(DisplayName = "ShipData:AutoMapper")]
        public void ShipDataMap()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(typeof(PortData).Assembly));
            var mapper = new Mapper(configuration);

            var port = new Port()
            {
                Id = "port id",
                IntlCode = "port intl code",
                Name = "port name"
            };
            var ship = new Ship("ship id", "ship name", "ship reg code", port);

            var shipData = mapper.Map<ShipData>(ship);

            Assert.Equal(ship.Id, shipData.Id);
            Assert.Equal(ship.RegistrationCode, shipData.RegistrationCode);
            Assert.Equal(ship.Name, shipData.Name);

            Assert.NotNull(shipData.Location);

            var portData = shipData.Location;

            Assert.Equal(port.Id, portData.Id);
            Assert.Equal(port.IntlCode, portData.IntlCode);
            Assert.Equal(port.Name, portData.Name);
        }
    }
}
