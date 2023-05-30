using WellMonitor.Core.Entities;

namespace WellMonitor.Core.Specifications.Well
{
    public class WellActiveSpecification : BaseSpecification<WellEntity>
    {
        public WellActiveSpecification() 
            : base(well => well.Active)
        {
            AddInclude(well => well.Company);
        }
    }
}
