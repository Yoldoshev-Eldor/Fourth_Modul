using E_CommerceSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_CommerceSystem.DataAccess.EntityConfiguration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product");

        builder.HasKey(p => p.ProductId);

        builder.Property(p => p.Name)
            .IsRequired(true)
            .HasMaxLength(20);


        builder.Property(p => p.Description)
            .IsRequired(true);

        builder.HasMany(p => p.Reviews)
            .WithOne(r => r.Product)
            .HasForeignKey(r => r.ProductId);

        builder.HasMany(p => p.Payment)
        .WithOne(pr => pr.Product)
        .HasForeignKey(p => p.ProductId);





    }
}
