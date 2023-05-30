using WellMonitor.Core.Entities;

namespace WellMonitor.Core.Specifications.Well
{
    public class WellWithTelemetriesSpecification : BaseSpecification<WellEntity>
    {
        public WellWithTelemetriesSpecification() : base()
        {
            AddInclude(w => w.Telemetries);
        }
    }
}
