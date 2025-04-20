using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.DataAccess.Entities;

namespace OnlineLearningPlatform.DataAccess.EntityConfiguration;

public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {

        builder.ToTable("Lesson");

        builder.HasKey(l => l.LessonId);
        builder.Property(l => l.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(l => l.VideoUrl)
            .IsRequired(true);

        builder.HasOne(l => l.Course)
               .WithMany(c => c.Lessons)
               .HasForeignKey(l => l.CourseId);
    }
}
