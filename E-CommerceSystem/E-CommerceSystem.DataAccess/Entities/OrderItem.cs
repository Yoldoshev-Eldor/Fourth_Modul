namespace E_CommerceSystem.DataAccess.Entities;

public class OrderItem
{
    public long OrderId { get; set; }
    public Order Order { get; set; }
    public long ProductId { get; set; }
    public ICollection<Product> Products { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }


}
