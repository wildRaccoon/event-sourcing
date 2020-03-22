using ev.lib.domain.app.services.tracking;
using ev.test.utils;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using ev.lib.domain.app.queries;
using Moq;
using System.Threading.Tasks;
using ev.lib.domain.core;
using System;
using ev.lib.domain.events;
using ev.lib.domain.app.services.queue;
using ev.lib.domain.app.services.reference;

namespace ev.test.domain.app.services
{
    public class TrackingServiceTest
    {
        [Fact(DisplayName = "ArrivalAsync:Success")]
        public void ArrivalAsyncTest()
        {
            var portQuery = Mock.Of<ISingleQueryPortByIntCode>();
            Mock.Get(portQuery).Setup(s => s.UseIntCode("port code")).Returns(portQuery).Verifiable();
            Mock.Get(portQuery).Setup(s => s.ExecuteAsync())
                .Returns(Task.FromResult(new Port()
                {
                    Id = "port id",
                    IntlCode = "port code",
                    Name = "port name"
                }));

            var ship = new Ship();
            var shipRef = new TestEntityRef<Ship>("ship id", ship);

            var shipQuery = Mock.Of<ISingleQueryShipByRegCode>(MockBehavior.Strict);
            ship.RegisterShip(new RegisterShipEvent(
                DateTime.Now,
                "event id",
                shipRef,
                new Port() { Id = "start port id", IntlCode = "start port", Name = "start port name" },
                "ship name",
                "ship code"
                ));
            Mock.Get(shipQuery).Setup(s => s.UseRegCode("ship code")).Returns(shipQuery).Verifiable();
            Mock.Get(shipQuery).Setup(s => s.ExecuteAsync())
                .Returns(Task.FromResult(ship));

            var sp = TestBed.Create<TrackingService>(MockBehavior.Strict, (sc) => {
                sc.AddSingleton<ISingleQueryPortByIntCode>(portQuery);
                sc.AddSingleton<ISingleQueryShipByRegCode>(shipQuery);
            });

            Mock.Get(sp.GetRequiredService<IQueueService>())
                .Setup(s => s.AddEvent<DomainEvent>(It.IsAny<ArriveEvent>()))
                .Callback((DomainEvent de) =>
                {
                    Assert.NotNull(de);

                    var ae = de as ArriveEvent;
                    Assert.NotNull(de);

                    Assert.Equal(shipRef, ae.Ship);
                    Assert.Equal("port id", ae.Port.Id);
                    Assert.Equal("port code", ae.Port.IntlCode);
                })
                .Returns(Task.CompletedTask);

            Mock.Get(sp.GetRequiredService<IReferenceService<Ship>>())
                .Setup(s => s.GetRef(shipQuery)).Returns(shipRef);

            var srv = sp.GetService<TrackingService>();

            srv.ArrivalAsync("event id", "ship code", "port code").GetAwaiter().GetResult();
        }
    }
}