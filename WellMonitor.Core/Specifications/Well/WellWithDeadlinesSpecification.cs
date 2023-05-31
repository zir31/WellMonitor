using WellMonitor.Core.Entities;

namespace WellMonitor.Core.Specifications.Well
{
    public class WellWithDeadlinesSpecification : BaseSpecification<WellEntity>
    {
        public WellWithDeadlinesSpecification() : base(w => w.Deadline != null)
        {
            AddInclude(w => w.Deadline);
        }
    }
}
