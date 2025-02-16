using E_CommerceSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_CommerceSystem.DataAccess.EntityConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.HasKey(u => u.UserId);

        builder.Property(u => u.Name)
            .HasMaxLength(40)
            .IsRequired(true);

        builder.Property(u => u.Email)
            .IsRequired(true)
            .HasMaxLength(200);

        builder.HasMany(u => u.Orders)
            .WithOne(o => o.User)
            .HasForeignKey(u => u.UserId);

            builder.HasMany(u => u.Reviews)
            .WithOne(o => o.User)
            .HasForeignKey(u => u.UserId);
            
    }
}
