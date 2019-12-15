using System.Threading.Tasks;

namespace ev.lib.domain.interfaces
{
    public interface ITrackingService
    {
        Task ArrivalAsync(string eventId,string shipCode, string portCode);
        Task DepartureAsync(string eventId,string shipCode, string portCode);
        Task RegisterShipAsync(string eventId, string shipCode, string portCode, string shipName);
    }
}