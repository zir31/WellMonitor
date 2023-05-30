using WellMonitor.Core.Entities;

namespace WellMonitor.Infrastructure.Repositories
{
    public class TelemetryRepository : RepositoryBase<TelemetryEntity>
    {
        public TelemetryRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}
