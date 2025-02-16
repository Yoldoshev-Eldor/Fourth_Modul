namespace E_CommerceSystem.DataAccess.Entities;

public class Cart
{
    public long CartId { get; set; }
    public ICollection<CartItem> CartItems { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
}
