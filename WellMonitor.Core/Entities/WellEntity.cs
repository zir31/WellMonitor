using WellMonitor.Core.Interfaces;

namespace WellMonitor.Core.Entities
{
    public class WellEntity : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Id_company { get; set; }

        public int Id_telemetry { get; set; }

        public int Active { get; set; }
    }
}
