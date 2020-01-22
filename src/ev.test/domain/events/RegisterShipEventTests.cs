using ev.lib.domain.core;
using ev.lib.domain.events;
using ev.test.utils;
using System;
using Xunit;

namespace ev.test.domain.events
{
    public class RegisterShipEventTests
    {
        [Fact(DisplayName = "RegisterShipEvent:Success")]
        public void RegisterShipEventSuccess()
        {
            var s = new Ship();
            var p = new Port() { Name = "port name", IntlCode = "int code of port" };

            var @event = new RegisterShipEvent(DateTime.Now, "id", new TestEntityRef<Ship>("id",s), p, "ship name", "ship reg code");

            @event.Process();

            Assert.Equal("ship name", s.Name);
            Assert.Equal("ship reg code", s.RegistrationCode);
            Assert.NotNull(s.Location);
            Assert.Equal(p, s.Location);
        }
    }
}
