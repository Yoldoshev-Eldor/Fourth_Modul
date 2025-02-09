using AvtoSalon.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvtoSalon.DataAccess.EntitieConfiguration;

public class AvtoSalonConfiguration : IEntityTypeConfiguration<AvtoSalonn>
{
    public void Configure(EntityTypeBuilder<AvtoSalonn> builder)
    {
        builder.ToTable("AvtoSalon");

        builder.HasKey( a => a.SalonId);

        builder.Property(a => a.SalonName)
            .IsRequired(true)
            .HasMaxLength(20);

        builder.HasIndex(a => a.SalonName)
            .IsUnique();

        builder.HasMany(a => a.Cars)
            .WithOne(c => c.AvtoSalon)
            .HasForeignKey(a => a.SalonId);
            
    }
}

