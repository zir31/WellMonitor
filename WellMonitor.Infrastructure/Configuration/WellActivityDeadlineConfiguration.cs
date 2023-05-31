using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WellMonitor.Core.Entities;

namespace WellMonitor.Infrastructure.Configuration
{
    public class WellActivityDeadlineConfiguration : IEntityTypeConfiguration<WellActivityDeadlineEntity>
    {
        public void Configure(EntityTypeBuilder<WellActivityDeadlineEntity> builder)
        {
            builder
                .HasKey(e => e.Id);

            builder
                .ToTable("t_well_deadline");

            builder
                .Property(e => e.WellId)
                .IsRequired();

            builder
                .Property(e => e.Deadline)
                .IsRequired();

            builder
                .HasOne(e => e.Well)
                .WithOne(e => e.Deadline)
                .HasForeignKey<WellActivityDeadlineEntity>(e => e.WellId);
        }
    }
}
