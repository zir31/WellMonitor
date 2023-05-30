using WellMonitor.Core.Entities;

namespace WellMonitor.Core.Specifications.Well
{
    public class WellByIdSpecification : BaseSpecification<WellEntity>
    {
        public WellByIdSpecification(int id) : base(well => well.Id == id)
        {

        }
    }
}
