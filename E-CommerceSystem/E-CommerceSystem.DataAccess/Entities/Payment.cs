using E_CommerceSystem.DataAccess.Enums;

namespace E_CommerceSystem.DataAccess.Entities;

public class Payment
{
    public long PaymentId { get; set; }

    public long OrderId { get; set; }
    public Order Order { get; set; }

    public double Amount { get; set; }

    public PaymentStatus Status { get; set; }
    public long ProductId { get; set; }
    public Product Product { get; set; }
}
