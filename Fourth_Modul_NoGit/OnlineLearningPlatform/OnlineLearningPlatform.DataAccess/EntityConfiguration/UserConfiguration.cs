using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.DataAccess.Entities;

namespace OnlineLearningPlatform.DataAccess.EntityConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {

        builder.ToTable("User");


        builder.HasKey(u => u.UserId);


        builder.Property(u => u.Name).IsRequired()
            .HasMaxLength(100);


        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(255);
       
        builder.HasMany(u => u.Enrollments)
               .WithOne(e => e.User)
               .HasForeignKey(e => e.UserId);



    }
}
