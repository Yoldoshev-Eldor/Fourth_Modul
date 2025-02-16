using E_CommerceSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_CommerceSystem.DataAccess.EntityConfiguration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Order");

        builder.HasKey(o => o.OrderId);

        builder.Property(o => o.UserId)
            .IsRequired(true);

        builder.Property(o => o.OrderDate)
            .IsRequired(true);
        
        builder.Property(o => o.Status)
            .IsRequired(true);


        builder.HasMany(o => o.OrderItems)
             .WithOne(oi => oi.Order)
             .HasForeignKey(oi => oi.OrderId);

            
    }
}
