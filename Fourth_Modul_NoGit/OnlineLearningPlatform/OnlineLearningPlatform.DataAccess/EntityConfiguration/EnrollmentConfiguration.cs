using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.DataAccess.Entities;

namespace OnlineLearningPlatform.DataAccess.EntityConfiguration;

public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> builder)
    {
        builder.ToTable("Enrollment");

        builder.HasKey(e => e.EnrollmentId);

        builder.HasOne(e => e.User)
               .WithMany(u => u.Enrollments)
               .HasForeignKey(e => e.UserId);

        builder.HasOne(e => e.Course)
               .WithMany(c => c.Enrollments)
               .HasForeignKey(e => e.CourseId);
    }
}
