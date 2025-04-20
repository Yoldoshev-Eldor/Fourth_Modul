namespace EventManagementSystem.Dal.Entities;

public class Event
{
    public long EventId { get; set; }
    public string Name { get; set; }
    public DateTime DateTime { get; set; }
    public string Location { get; set; }
    public ICollection<User> Users { get; set; }
    public ICollection<Ticket> Tickets { get; set; }
    public ICollection<FeedBack> FeedBacks { get; set; }

}
