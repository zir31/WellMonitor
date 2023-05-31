using WellMonitor.Core.Entities;

namespace WellMonitor.Core.Specifications.Well
{
    public class WellByIdSpecification : BaseSpecification<WellEntity>
    {
        public WellByIdSpecification(int id) : base(w => w.Id == id)
        {
            AddInclude(w => w.Telemetries);
            AddInclude(w => w.Deadline);
        }
    }
}
