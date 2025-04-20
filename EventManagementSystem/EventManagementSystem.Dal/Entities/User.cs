using EventManagementSystem.Dal.Enums;

namespace EventManagementSystem.Dal.Entities;

public class User
{
    public long UserID { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public UserRole Role { get; set; }
    public Ticket Ticket { get; set; }
    public  ICollection<FeedBack> FeedBacks { get; set; }


}
