using WellMonitor.Core.Interfaces;

namespace WellMonitor.Core.Entities
{
    public class CompanyEntity : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<WellEntity> Wells { get; set; } = new List<WellEntity>();
    }
}
