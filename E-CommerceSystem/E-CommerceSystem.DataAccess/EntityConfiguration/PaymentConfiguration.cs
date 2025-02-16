using E_CommerceSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_CommerceSystem.DataAccess.EntityConfiguration;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("Payment");

        builder.HasKey(p => p.PaymentId);

        builder.Property(p => p.Amount)
            .IsRequired(true);

        builder.Property(p => p.Status)
        .IsRequired(true);

       

    }
}
