using ev.lib.domain.app.services.tracking;
using ev.test.utils;
using Xunit;

namespace ev.test.domain.app.services
{
    public class TrackingServiceTest
    {
        [Fact(DisplayName = "ArrivalAsync:Success")]
        public void ArrivalAsyncTest()
        {
            var serviceProvider = TestBed.Create<TrackingService>();
        }
    }
}