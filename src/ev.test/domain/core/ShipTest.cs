using ev.lib.domain.core;
using System;
using Xunit;

namespace ev.test.domain.core
{
    public class ShipTest
    {
        [Fact(DisplayName = "RegisterShip:Success")]
        public void RegisterShipSuccess()
        {
            var ship = new Ship();
            ship.RegisterShip("name", "code", new Port("port"));

            Assert.Equal("name", ship.Name);
            Assert.Equal("code", ship.RegistrationCode);
            Assert.NotNull(ship.Location);
            Assert.Equal("port", ship.Location.Name);
        }

        [Fact(DisplayName = "RegisterShip:Already Registered")]
        public void RegisterShipAlreadyRegistered()
        {
            var ship = new Ship();
            ship.RegisterShip("name", "code", new Port("port"));

            Assert.Equal("name", ship.Name);
            Assert.Equal("code", ship.RegistrationCode);
            Assert.NotNull(ship.Location);
            Assert.Equal("port", ship.Location.Name);

            Assert.Throws<Exception>(() => ship.RegisterShip("other name", "other code", new Port("other port")));
        }

        [Fact(DisplayName = "RegisterShip:Null Port")]
        public void RegisterShipNullPort()
        {
            var ship = new Ship();

            Assert.Throws<Exception>(() => ship.RegisterShip("name", "code", null));
        }

        [Fact(DisplayName = "RegisterShip:At Sea Port")]
        public void RegisterShipAtSeaPort()
        {
            var ship = new Ship();

            Assert.Throws<Exception>(() => ship.RegisterShip("name", "code", Port.AT_SEA));
        }
    }
}
