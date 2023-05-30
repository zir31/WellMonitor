using WellMonitor.Core.Entities;

namespace WellMonitor.Application.Dtos.Telemetry
{
    public record TelemetryAddRequest
    {
        public int WellId { get; set; }

        public DateTime Date_time { get; set; }

        public float Depth { get; set; }
    }
}
