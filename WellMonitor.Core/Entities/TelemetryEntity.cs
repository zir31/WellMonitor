using WellMonitor.Core.Interfaces;

namespace WellMonitor.Core.Entities
{
    public class TelemetryEntity : IEntity
    {
        public int Id { get; set; }

        public int WellId { get; set; }

        public WellEntity Well { get; set; }

        public DateTime Date_time { get; set; }

        public float Depth { get; set; }
    }
}
