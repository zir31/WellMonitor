using WellMonitor.Core.Entities;
using WellMonitor.Core.Interfaces;

namespace WellMonitor.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryBase<WellEntity> WellRepository { get; set; }

        IRepositoryBase<CompanyEntity> CompanyRepository { get; set; }

        IRepositoryBase<TelemetryEntity> TelemetryRepository { get; set; }

        Task SaveChangesAsync();
    }
}
