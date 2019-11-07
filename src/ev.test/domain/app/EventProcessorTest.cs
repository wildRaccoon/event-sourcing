using System;
using ev.lib.domain.app;
using ev.lib.domain.events;
using ev.lib.domain.interfaces;
using Moq;
using Xunit;
using  Microsoft.Extensions.DependencyInjection;

namespace ev.test.domain.app
{
    public class EventProcessorTest
    {
        private class CustomDomainEvent : DomainEvent
        {
            public bool IsProcessed { get; set; } = false;

            public CustomDomainEvent() : base(DateTime.MaxValue)
            {
                
            }

            public override void Process()
            {
                IsProcessed = true;
            }
        }
        
        [Fact(DisplayName = "ProcessAsync:Success")]
        public void ProcessAsyncSuccess()
        {
            var sp = TestUtil.GetServiceProvider<EventProcessor>();

            var eventProc = sp.GetService<EventProcessor>();
            
            var @event = new CustomDomainEvent();

            //save before process
            sp.GetService<Mock<IRepository>>()
                .Setup(s => s.AddAsync(@event))
                .Callback((CustomDomainEvent @e) => { Assert.False(@e.IsProcessed); });
            
            //send notification after
            sp.GetService<Mock<IEventGateway>>()
                .Setup(s => s.PublishAsync(@event))
                .Callback((CustomDomainEvent @e) => { Assert.True(@e.IsProcessed); });

            
            var result = eventProc
                .ProcessAsync(@event)
                .GetAwaiter()
                .GetResult();

            Assert.True(result.IsProcessed);
        }
    }
}