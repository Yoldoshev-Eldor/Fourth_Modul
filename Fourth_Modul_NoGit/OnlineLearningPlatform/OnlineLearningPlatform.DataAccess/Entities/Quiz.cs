namespace OnlineLearningPlatform.DataAccess.Entities;

public class Quiz
{
    public long QuizId { get; set; }
    public string Title { get; set; }
    public long CourseId { get; set; }
    public Course Course { get; set; }
    public List<string> Questions { get; set; }

}
