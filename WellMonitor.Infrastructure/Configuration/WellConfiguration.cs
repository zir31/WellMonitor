using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WellMonitor.Core.Entities;

namespace WellMonitor.Infrastructure.Configuration
{
    public class WellConfiguration : IEntityTypeConfiguration<WellEntity>
    {
        public void Configure(EntityTypeBuilder<WellEntity> builder)
        {
            builder
                .HasKey(w => w.Id);

            builder
                .ToTable("t_well");

            builder
                .Property(w => w.Name);

            builder
                .Property(w => w.Id_company);

            builder
                .Property(w => w.Active)
                .IsRequired();

            builder
                .HasOne(w => w.Company)
                .WithMany(c => c.Wells)
                .HasForeignKey(w => w.Id_company)
                .OnDelete(DeleteBehavior.NoAction);

            
        }
    }
}
