using ev.lib.domain.app.queries;
using ev.lib.domain.app.services.queue;
using ev.lib.domain.app.services.reference;
using ev.lib.domain.core;
using ev.lib.domain.events;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace ev.lib.domain.app.services.tracking
{
    public class TrackingService : ITrackingService
    {
        IServiceScope serviceScope;
        IServiceProvider serviceProvider;
        IReferenceService<Ship> referenceService;
        IQueueService queueService;

        public TrackingService(IServiceProvider serviceProvider, IReferenceService<Ship> referenceService, IQueueService queueService)
        {
            this.serviceScope = serviceProvider.CreateScope();
            this.serviceProvider = serviceScope.ServiceProvider;
            this.referenceService = referenceService;
            this.queueService = queueService;
        }

        public async Task ArrivalAsync(string eventId, string shipCode, string portCode)
        {
            var port = await serviceProvider.GetService<ISingleQueryPortByIntCode>().UseIntCode(portCode).ExecuteAsync();
            var shipQuery = serviceProvider.GetService<ISingleQueryShipByRegCode>().UseRegCode(shipCode);
            var shipRef = referenceService.GetRef(shipQuery);

            var @event = new ArriveEvent(DateTime.Now, eventId, shipRef, port);

            await queueService.AddEvent(@event);
        }

        public async Task DepartureAsync(string eventId, string shipCode, string portCode)
        {
            var port = await serviceProvider.GetService<ISingleQueryPortByIntCode>().UseIntCode(portCode).ExecuteAsync();
            var shipQuery = serviceProvider.GetService<ISingleQueryShipByRegCode>().UseRegCode(shipCode);
            var shipRef = referenceService.GetRef(shipQuery);

            var @event = new DepartureEvent(DateTime.Now, eventId, shipRef, port);

            await queueService.AddEvent(@event);
        }

        public async Task RegisterShipAsync(string eventId, string shipCode, string portCode, string shipName)
        {
            var port = await serviceProvider.GetService<ISingleQueryPortByIntCode>().UseIntCode(portCode).ExecuteAsync();
            var shipRef = referenceService.GetRef();

            var @event = new RegisterShipEvent(DateTime.Now, eventId, shipRef, port, shipName, shipCode);

            await queueService.AddEvent(@event);
        }
    }
}
