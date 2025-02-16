using E_CommerceSystem.DataAccess.Enums;

namespace E_CommerceSystem.DataAccess.Entities;

public class Order
{
    public long OrderId { get; set; }
    public long UserId { get; set; }

    public User User { get; set; }
    public DateTime OrderDate { get; set; }
    public OrderStatus Status { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }

}
