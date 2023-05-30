using WellMonitor.Core.Entities;

namespace WellMonitor.Core.Specifications.Well
{
    public class WellByIdBetweenDatesSpecification : BaseSpecification<WellEntity>
    {
        public WellByIdBetweenDatesSpecification(int id, DateTime dateStart, DateTime dateEnd) 
            : base(well => well.Id == id)
        {
            AddInclude(well => well.Company);
            AddInclude(well => well.Telemetries.Where(x => x.Date_time >= dateStart && x.Date_time < dateEnd));
        }
    }
}
