using ev.lib.domain.app.services.queue;
using ev.lib.domain.events;
using ev.test.utils;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.DependencyInjection;

namespace ev.test.domain.app.services
{
    public class QueueServiceTests
    {
        private class MyDomainEvent : DomainEvent
        {
            public MyDomainEvent(string id) : base(DateTime.MinValue, id)
            {
                Id = id;
            }

            public bool Processed = false;
            public string Id;

            public override async Task Process()
            {
                Processed = true;
            }
        }

        [Fact(DisplayName = "ProcessEvents")]
        public void ProcessEvents()
        {
            var sp = TestBed.Create<QueueService>(MockBehavior.Loose);

            var srv = sp.GetService<QueueService>();

            var @e1 = new MyDomainEvent("1");
            var @e2 = new MyDomainEvent("2");

            Task.Run( async () =>
            {
                await srv.AddEvent(@e1);
                await Task.Delay(100);
                await srv.AddEvent(@e2);
            }).Wait();

            Assert.True(@e1.Processed);
            Assert.Equal("1",@e1.Id);

            Assert.True(@e2.Processed);
            Assert.Equal("2", @e2.Id);
        }
    }
}
