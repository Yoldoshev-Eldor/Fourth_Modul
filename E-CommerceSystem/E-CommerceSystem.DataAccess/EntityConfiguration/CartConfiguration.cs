using E_CommerceSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_CommerceSystem.DataAccess.EntityConfiguration;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.ToTable("Cart");

        builder.HasKey(c => c.CartId);


        builder.HasOne(c => c.User)
            .WithOne(u => u.Cart);

        builder.HasMany(c => c.CartItems)
            .WithOne(i => i.Cart)
            .HasForeignKey(c => c.CartId);
    }
}
