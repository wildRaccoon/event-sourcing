using System;
using ev.lib.domain.core;
using ev.lib.domain.events;
using ev.test.utils;
using Xunit;

namespace ev.test.domain.events
{
    public class DepartureShipEventTests
    {
        [Fact(DisplayName = "DepartureShipEvent:Success")]
        public void DepartureShipEventSuccess()
        {
            var p = new Port() { Name = "port name", IntlCode = "intl code of port" };
            var s = new Ship("id", "ship name", "ship reg code", p);

            var @event = new DepartureEvent(DateTime.Now, "id", new TestEntityRef<Ship>("id",s), p);

            @event.Process();

            Assert.Equal("ship name", s.Name);
            Assert.Equal("ship reg code", s.RegistrationCode);
            Assert.NotNull(s.Location);
            Assert.Equal(Port.AT_SEA.IntlCode, s.Location.IntlCode);
        }
    }
}