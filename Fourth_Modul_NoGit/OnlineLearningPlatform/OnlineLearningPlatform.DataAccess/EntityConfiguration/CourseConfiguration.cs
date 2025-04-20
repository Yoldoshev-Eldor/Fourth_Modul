using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.DataAccess.Entities;

namespace OnlineLearningPlatform.DataAccess.EntityConfiguration;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("Course");

        builder.HasKey(c => c.CourseId);
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(c => c.Description).HasMaxLength(1000);

        builder.HasMany(c => c.Lessons)
               .WithOne(l => l.Course)
               .HasForeignKey(l => l.CourseId);

        builder.HasMany(c => c.Quizs)
               .WithOne(q => q.Course)
               .HasForeignKey(q => q.CourseId);

        builder.HasMany(c => c.User)
            .WithMany(u => u.Courses);


    }
}
