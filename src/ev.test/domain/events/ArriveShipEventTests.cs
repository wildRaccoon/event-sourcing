using System;
using ev.lib.domain.core;
using ev.lib.domain.events;
using Xunit;

namespace ev.test.domain.events
{
    public class ArriveShipEventTests
    {
        [Fact(DisplayName = "ArriveShipEvent:Success")]
        public void ArriveShipEventSuccess()
        {
            var p = new Port() { Name = "port name", InternationalCode = "intl code of port" };
            var s = new Ship("id", "ship name", "ship reg code", Port.AT_SEA);

            var @event = new ArriveEvent(DateTime.Now, s, p);

            @event.Process();

            Assert.Equal("ship name", s.Name);
            Assert.Equal("ship reg code", s.RegistrationCode);
            Assert.NotNull(s.Location);
            Assert.Equal(p, s.Location);
        }
    }
}