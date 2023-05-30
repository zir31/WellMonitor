using WellMonitor.Core.Entities;

namespace WellMonitor.Core.Specifications.Well
{
    public class WellByCompanyIdOrNameSpecification : BaseSpecification<WellEntity>
    {
        public WellByCompanyIdOrNameSpecification(int? id, string name) 
            : base(well => well.Company.Id == id || well.Company.Name == name)
        {
            AddInclude(well => well.Company);
        }
    }
}
