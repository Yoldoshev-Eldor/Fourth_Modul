namespace EventManagementSystem.Dal.Entities;

public class FeedBack
{
    public long FeedBackID { get; set; }
    public long EventID { get; set; }
    public Event Event { get; set; }
    public long UserID { get; set; }
    public User User { get; set; }
    public double Rating { get; set; }
    public string Comment { get; set; }
}
