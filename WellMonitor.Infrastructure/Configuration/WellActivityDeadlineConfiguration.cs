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
                .Property(e => e.WellId)
                .IsRequired();

            builder
                .Property(e => e.Deadline)
                .IsRequired();

            builder
                .HasOne(e => e.Well)
                .WithOne()
                .HasForeignKey<WellActivityDeadlineEntity>(e => e.WellId);
        }
    }
}
