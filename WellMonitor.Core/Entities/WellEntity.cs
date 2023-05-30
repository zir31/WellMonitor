using WellMonitor.Core.Interfaces;

namespace WellMonitor.Core.Entities
{
    public class WellEntity : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Id_company { get; set; }

        public CompanyEntity Company { get; set; }

        public bool Active { get; set; }

        public IEnumerable<TelemetryEntity> Telemetries { get; set; } = new List<TelemetryEntity>();
    }
}
