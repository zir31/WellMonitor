using WellMonitor.Core.Entities;

namespace WellMonitor.Core.Specifications.Well
{
    public class WellActiveByCompanyIdBetweenDatesSpecification : BaseSpecification<WellEntity>
    {
        public WellActiveByCompanyIdBetweenDatesSpecification(int companyId, DateTime dateStart, DateTime dateEnd) 
            : base(well => well.Company.Id == companyId && well.Active)
        {
            AddInclude(well => well.Company);
            AddInclude(well => well.Telemetries.Where(x => x.Date_time >= dateStart && x.Date_time < dateEnd));
        }
    }
}
