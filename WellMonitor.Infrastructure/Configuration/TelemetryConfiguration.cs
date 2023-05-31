using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WellMonitor.Core.Entities;

namespace WellMonitor.Infrastructure.Configuration
{
    public class TelemetryConfiguration : IEntityTypeConfiguration<TelemetryEntity>
    {
        public void Configure(EntityTypeBuilder<TelemetryEntity> builder)
        {
            builder
                .HasKey(t => t.Id);

            builder
                .ToTable("t_telemetry");

            builder
                .Property(t => t.Date_time)
                .IsRequired();

            builder
                .Property(t => t.Depth)
                .IsRequired();

            builder
                .HasOne(t => t.Well)
                .WithMany(w => w.Telemetries)
                .HasForeignKey(t => t.WellId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
