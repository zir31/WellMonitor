using WellMonitor.Core.Entities;

namespace WellMonitor.Infrastructure.Repositories
{
    public class CompanyRepository : RepositoryBase<CompanyEntity>
    {
        public CompanyRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}
