using E_CommerceSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_CommerceSystem.DataAccess.EntityConfiguration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Category");

        builder.HasKey(c => c.CategoryId);

        builder.Property(c => c.Name)
            .IsRequired(true)
            .HasMaxLength(50);

        builder.HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(c => c.ProductId);
          
    }
}
