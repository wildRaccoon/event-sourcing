using ev.lib.domain.core;
using ev.lib.domain.events;
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
            var p = new Port() { Name = "port name", InternationalCode = "int code of port" };

            var @event = new RegisterShipEvent(DateTime.Now, s, p, "ship name", "ship reg code");
            
            @event.Process();

            Assert.Equal("ship name", s.Name);
            Assert.Equal("ship reg code", s.RegistrationCode);
            Assert.NotNull(s.Location);
            Assert.Equal(p, s.Location);
        }
    }
}
