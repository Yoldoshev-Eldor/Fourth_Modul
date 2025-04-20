using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.DataAccess.Entities;

namespace OnlineLearningPlatform.DataAccess.EntityConfiguration;

public class QuizConfiguration : IEntityTypeConfiguration<Quiz>
{
    public void Configure(EntityTypeBuilder<Quiz> builder)
    {

        builder.ToTable("Quiz");

        builder.HasKey(q => q.QuizId);
        builder.Property(q => q.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasOne(q => q.Course)
               .WithMany(c => c.Quizs)
               .HasForeignKey(q => q.CourseId);
    }
}
