using E_CommerceSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_CommerceSystem.DataAccess.EntityConfiguration;

public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.ToTable("CartItem");

        builder.HasKey(c => c.CartId);

        builder.Property(c => c.Quantity)
            .IsRequired(true);

        builder.HasMany(c => c.Products)
            .WithOne(p => p.CartItem)
            .HasForeignKey(c => c.ProductId);
            
    }
}
