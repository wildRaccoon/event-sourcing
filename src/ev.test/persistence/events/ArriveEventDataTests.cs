using Xunit;
using AutoMapper;
using ev.lib.persistence.events;
using ev.lib.domain.events;
using System;
using ev.lib.domain.core;

namespace ev.test.persistence.events
{
    public class ArriveEventDataTests
    {
        [Fact(DisplayName = "ArriveEventDataTests:AutoMapper")]
        public void ArriveEventDataMap()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(typeof(ArriveEventData).Assembly);
            });

            var mapper = new Mapper(configuration);

            var arriveEvent = new ArriveEvent(DateTime.Now, "id", new Ship("ship id", "", "", Port.AT_SEA), new Port() { Id = "port id", Name = "port name", IntlCode = "intl code" });
            var arriveEventData = mapper.Map<ArriveEventData>(arriveEvent);

            Assert.Equal(arriveEvent.EventId, arriveEventData.EventId);
            Assert.Equal(arriveEvent.Ship.Id, arriveEventData.ShipId);
            Assert.Equal(arriveEvent.Port.IntlCode, arriveEventData.PortIntlCode);
            Assert.Equal(new DateTimeOffset(arriveEvent.Occured).ToUnixTimeMilliseconds(), arriveEventData.Occured);
            Assert.Equal(new DateTimeOffset(arriveEvent.Recorded).ToUnixTimeMilliseconds(), arriveEventData.Recorded);
        }
    }
}