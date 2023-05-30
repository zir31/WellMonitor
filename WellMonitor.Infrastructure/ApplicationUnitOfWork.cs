using WellMonitor.Core.Entities;
using WellMonitor.Core.Interfaces;
using WellMonitor.Infrastructure.Interfaces;

namespace WellMonitor.Infrastructure
{
    public class ApplicationUnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;

        public IRepositoryBase<WellEntity> WellRepository { get; set; }
        public IRepositoryBase<CompanyEntity> CompanyRepository { get; set; }
        public IRepositoryBase<TelemetryEntity> TelemetryRepository { get; set; }

        public ApplicationUnitOfWork(ApplicationDbContext context,
            IRepositoryBase<WellEntity> wellRepository,
            IRepositoryBase<CompanyEntity> companyRepository,
            IRepositoryBase<TelemetryEntity> telemetryRepository)

        {
            _context = context;
            WellRepository = wellRepository;
            CompanyRepository = companyRepository;
            TelemetryRepository = telemetryRepository;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
