namespace E_CommerceSystem.DataAccess.Entities;

public class CartItem
{
    public long CartId { get; set; }
    public Cart Cart { get; set; }
    public long ProductId { get; set; }
    public ICollection<Product> Products { get; set; }

    public double Quantity { get; set; }
}
