using WellMonitor.Application.Dtos;
using WellMonitor.Application.Dtos.Telemetry;

namespace WellMonitor.Application.Interfaces
{
    public interface ITelemetryService
    {
        Task AddTelemetries(IEnumerable<TelemetryAddRequest> requests);

        Task GenerateRandomTelemetries();
    }
}
