namespace EventManagementSystem.Dal.Entities;

public class Payment
{
    public long PaymentID { get; set; }
    public long TicketID { get; set; }
    public Ticket Ticket { get; set; }
    public double Amount { get; set; }

}
