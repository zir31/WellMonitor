using WellMonitor.Core.Entities;

namespace WellMonitor.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryBase<WellEntity> WellRepository { get; set; }

        IRepositoryBase<CompanyEntity> CompanyRepository { get; set; }

        IRepositoryBase<TelemetryEntity> TelemetryRepository { get; set; }

        IRepositoryBase<WellActivityDeadlineEntity> WellActivityDeadlineRepository { get; set; }

        Task SaveChangesAsync();
    }
}
