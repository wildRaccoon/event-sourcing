using ev.lib.domain.app.services.tracking;
using ev.lib.domain.core;
using ev.lib.domain.interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ev.cmd
{
    public class ConsoleHostService : IHostedService
    {
        ILogger<ConsoleHostService> logger;
        IRepository<Port> repository;
        ITrackingService trackingService;

        public ConsoleHostService(ILogger<ConsoleHostService> logger, IRepository<Port> repository, ITrackingService trackingService)
        {
            this.logger = logger;
            this.trackingService = trackingService;
            this.repository = repository;
        }

        private async Task RunJob(CancellationToken cancellationToken)
        {
            await repository.AddAsync(new Port() { IntlCode = "p1", Name = "port name 1" });
            await repository.AddAsync(new Port() { IntlCode = "p2", Name = "port name 2" });
            await repository.AddAsync(new Port() { IntlCode = "p3", Name = "port name 3" });

            await trackingService.RegisterShipAsync(Guid.NewGuid().ToString(), "s1", "p1", "ship name 1");
            await trackingService.RegisterShipAsync(Guid.NewGuid().ToString(), "s2", "p1", "ship name 2");

            await trackingService.DepartureAsync(Guid.NewGuid().ToString(), "s1", "p2");
            await trackingService.DepartureAsync(Guid.NewGuid().ToString(), "s2", "p3");

            await trackingService.ArrivalAsync(Guid.NewGuid().ToString(), "s1", "p2");
            await trackingService.ArrivalAsync(Guid.NewGuid().ToString(), "s2", "p3");

            cancellationToken.WaitHandle.WaitOne();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogDebug("Start console service");

            await RunJob(cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogDebug("Stop console service");
        }
    }
}
