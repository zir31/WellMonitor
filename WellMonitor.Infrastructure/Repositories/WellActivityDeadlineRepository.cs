using WellMonitor.Core.Entities;

namespace WellMonitor.Infrastructure.Repositories
{
    public class WellActivityDeadlineRepository : RepositoryBase<WellActivityDeadlineEntity>
    {
        public WellActivityDeadlineRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}
