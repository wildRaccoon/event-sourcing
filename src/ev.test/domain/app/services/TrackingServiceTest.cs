using ev.lib.domain.app.services.tracking;
using ev.test.utils;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using ev.lib.domain.app.queries;
using Moq;
using System.Threading.Tasks;
using ev.lib.domain.core;

namespace ev.test.domain.app.services
{
    public class TrackingServiceTest
    {
        [Fact(DisplayName = "ArrivalAsync:Success")]
        public void ArrivalAsyncTest()
        {
            var sp = TestBed.Create<TrackingService>(MockBehavior.Strict);

            var queryMock = Mock.Get(sp.GetService<IQueryPortByIntCode>());

            queryMock.Setup(s => s.Execute("port code"))
                .Returns(Task.FromResult(new Port() { Id = "id of port", IntlCode = "port code", Name = "port name" }));

            var srv = sp.GetService<TrackingService>();

            srv.ArrivalAsync("event id", "ship code", "port code").GetAwaiter().GetResult();
        }
    }
}