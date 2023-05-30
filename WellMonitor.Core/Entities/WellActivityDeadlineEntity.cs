using WellMonitor.Core.Interfaces;

namespace WellMonitor.Core.Entities
{
    public class WellActivityDeadlineEntity : IEntity
    {
        public int Id { get; set; }

        public int WellId { get; set; }

        public DateTime Deadline { get; set; }

        public WellEntity Well { get; set; }
    }
}
