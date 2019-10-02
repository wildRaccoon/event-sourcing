using ev.lib.domain.core;
using ev.lib.domain.events;
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
            ship.RegisterShip(new RegisterShipEvent(ship, new Port() { Name = "port" }, "name", "code"));

            Assert.Equal("name", ship.Name);
            Assert.Equal("code", ship.RegistrationCode);
            Assert.NotNull(ship.Location);
            Assert.Equal("port", ship.Location.Name);
        }

        [Fact(DisplayName = "RegisterShip:Already Registered")]
        public void RegisterShipAlreadyRegistered()
        {
            var ship = new Ship();
            ship.RegisterShip(new RegisterShipEvent(ship, new Port() { Name = "port" }, "name", "code"));

            Assert.Equal("name", ship.Name);
            Assert.Equal("code", ship.RegistrationCode);
            Assert.NotNull(ship.Location);
            Assert.Equal("port", ship.Location.Name);

            Assert.Throws<Exception>(() => ship.RegisterShip(new RegisterShipEvent(ship, new Port() { Name = "other port" }, "other name", "other code")));
        }

        [Fact(DisplayName = "RegisterShip:Null Port")]
        public void RegisterShipNullPort()
        {
            var ship = new Ship();

            Assert.Throws<Exception>(() => ship.RegisterShip(new RegisterShipEvent(ship, null, "name", "code")));
        }

        [Fact(DisplayName = "RegisterShip:At Sea Port")]
        public void RegisterShipAtSeaPort()
        {
            var ship = new Ship();

            Assert.Throws<Exception>(() => ship.RegisterShip(new RegisterShipEvent(ship, Port.AT_SEA, "name", "code")));
        }
    }
}
