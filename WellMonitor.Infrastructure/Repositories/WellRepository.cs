using WellMonitor.Core.Entities;

namespace WellMonitor.Infrastructure.Repositories
{
    public class WellRepository : RepositoryBase<WellEntity>
    {
        public WellRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}
