namespace OnlineLearningPlatform.DataAccess.Entities;

public class Course
{
    public long CourseId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public long UserId { get; set; }
    public ICollection<User> User { get; set; }
    public ICollection<Quiz> Quizs { get; set; }
    public ICollection<Lesson> Lessons { get; set; }
    public ICollection<Enrollment> Enrollments { get; set; }
}
