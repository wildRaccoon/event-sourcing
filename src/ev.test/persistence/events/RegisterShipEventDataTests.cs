using AutoMapper;
using ev.lib.domain.core;
using ev.lib.domain.events;
using ev.lib.persistence.events;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ev.test.persistence.events
{
    public class RegisterShipEventDataTests
    {
        [Fact(DisplayName = "RegisterShipEventDataTests:AutoMapper")]
        public void RegisterShipDataMap()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(typeof(RegisterShipEventData).Assembly);
            });

            var mapper = new Mapper(configuration);

            var registerShipEvent = new RegisterShipEvent(DateTime.Now, "id", new Ship("id"), new Port() { Id = "port id", Name = "port name", IntlCode = "intl code" },"ship name", "ship code");
            var registerShipEventData = mapper.Map<RegisterShipEventData>(registerShipEvent);

            Assert.Equal(registerShipEvent.EventId, registerShipEventData.EventId);
            Assert.Equal(registerShipEvent.Ship.Id, registerShipEventData.ShipId);
            Assert.Equal(registerShipEvent.Port.IntlCode, registerShipEventData.PortIntlCode);
            Assert.Equal(registerShipEvent.Name, registerShipEventData.Name);
            Assert.Equal(registerShipEvent.Code, registerShipEventData.Code);
            Assert.Equal(new DateTimeOffset(registerShipEvent.Occured).ToUnixTimeMilliseconds(), registerShipEventData.Occured);
            Assert.Equal(new DateTimeOffset(registerShipEvent.Recorded).ToUnixTimeMilliseconds(), registerShipEventData.Recorded);
        }
    }
}
