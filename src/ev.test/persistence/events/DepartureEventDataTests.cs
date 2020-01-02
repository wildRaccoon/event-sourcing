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
    public class DepartureEventDataTests
    {
        [Fact(DisplayName = "DepartureEventDataTests:AutoMapper")]
        public void DepartureEventDataMap()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(typeof(DepartureEventData).Assembly);
            });

            var mapper = new Mapper(configuration);

            var departureEvent = new DepartureEvent(DateTime.Now, "id", new Ship("ship id", "", "", Port.AT_SEA), new Port() { Id = "port id", Name = "port name", IntlCode = "intl code" });
            var departureEventData = mapper.Map<DepartureEventData>(departureEvent);

            Assert.Equal(departureEvent.Id, departureEventData.Id);
            Assert.Equal(departureEvent.Ship.Id, departureEventData.ShipId);
            Assert.Equal(departureEvent.Port.IntlCode, departureEventData.PortIntlCode);
            Assert.Equal(new DateTimeOffset(departureEvent.Occured).ToUnixTimeMilliseconds(), departureEventData.Occured);
            Assert.Equal(new DateTimeOffset(departureEvent.Recorded).ToUnixTimeMilliseconds(), departureEventData.Recorded);
        }
    }
}
