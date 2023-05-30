using WellMonitor.Core.Entities;

namespace WellMonitor.Core.Specifications.Well
{
    public class WellActiveByCompanyIdOrNameSpecification : BaseSpecification<WellEntity>
    {
        public WellActiveByCompanyIdOrNameSpecification(int? id, string name) 
            : base(well => (well.Company.Id == id || well.Company.Name == name)
                            && well.Active)
        {
            AddInclude(well => well.Company);
        }
    }
}
