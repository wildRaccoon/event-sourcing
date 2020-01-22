using System.Threading.Tasks;

namespace ev.lib.domain.app.services.tracking
{
    public interface ITrackingService
    {
        Task ArrivalAsync(string eventId,string shipId, string portCode);
        Task DepartureAsync(string eventId,string shipId, string portCode);
        Task RegisterShipAsync(string eventId, string shipCode, string portCode, string shipName);
    }
}