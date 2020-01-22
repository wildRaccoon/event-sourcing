using ev.lib.domain.app.queries;
using ev.lib.domain.app.services.queue;
using ev.lib.domain.app.services.reference;
using ev.lib.domain.core;
using ev.lib.domain.events;
using System;
using System.Threading.Tasks;

namespace ev.lib.domain.app.services.tracking
{
    public class TrackingService : ITrackingService
    {
        IQueryPortByIntCode queryPortByIntCode;
        IReferenceService<Ship> referenceService;
        IQueueService queueService;

        public TrackingService(IQueryPortByIntCode queryPortByIntCode, IReferenceService<Ship> referenceService, IQueueService queueService)
        {
            this.queryPortByIntCode = queryPortByIntCode;
            this.referenceService = referenceService;
            this.queueService = queueService;
        }

        public async Task ArrivalAsync(string eventId, string shipCode, string portCode)
        {
            var port = await queryPortByIntCode.Execute(portCode);
            var shipRef = referenceService.GetRef(p => p.RegistrationCode, shipCode);

            var @event = new ArriveEvent(DateTime.Now, eventId, shipRef, port);

            queueService.AddEvent(@event);
        }

        public async Task DepartureAsync(string eventId, string shipCode, string portCode)
        {
            var port = await queryPortByIntCode.Execute(portCode);
            var shipRef = referenceService.GetRef(p => p.RegistrationCode, shipCode);

            var @event = new DepartureEvent(DateTime.Now, eventId, shipRef, port);

            queueService.AddEvent(@event);
        }

        public async Task RegisterShipAsync(string eventId, string shipCode, string portCode, string shipName)
        {
            var port = await queryPortByIntCode.Execute(portCode);
            var shipRef = referenceService.GetRef();

            var @event = new RegisterShipEvent(DateTime.Now, eventId, shipRef, port, shipName, shipCode);

            queueService.AddEvent(@event);
        }
    }
}
