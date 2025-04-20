using System.Reflection.Metadata.Ecma335;

namespace EventManagementSystem.Dal.Entities;

public class Ticket
{
    public long TickesID { get; set; }
    public Event Event { get; set; }
    public long EventID { get; set; }
    public User User { get; set; }
    public long UserID { get; set; }
    public double Price { get; set; }
    public int SeatNumber { get; set; }
    public Payment Payment { get; set; }




}
