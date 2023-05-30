using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WellMonitor.Core.Entities;

namespace WellMonitor.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<WellEntity> t_well { get; set; }

        public DbSet<CompanyEntity> t_company { get; set; }
        
        public DbSet<TelemetryEntity> t_telemetry { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
