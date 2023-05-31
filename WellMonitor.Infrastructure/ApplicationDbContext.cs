using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WellMonitor.Core.Entities;

namespace WellMonitor.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<WellEntity> Wells { get; set; }

        public DbSet<CompanyEntity> Companies { get; set; }
        
        public DbSet<TelemetryEntity> Telemetries { get; set; }

        public DbSet<WellActivityDeadlineEntity> WellActivityDeadlines { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
