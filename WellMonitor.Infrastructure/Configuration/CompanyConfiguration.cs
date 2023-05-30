using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WellMonitor.Core.Entities;

namespace WellMonitor.Infrastructure.Configuration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<CompanyEntity>
    {
        public void Configure(EntityTypeBuilder<CompanyEntity> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Name)
                .IsRequired();
        }
    }
}
