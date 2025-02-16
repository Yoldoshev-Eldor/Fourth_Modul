namespace E_CommerceSystem.DataAccess.Entities;

public class Product
{
    public long ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public ICollection<Payment> Payment { get; set; }
    public Category Category { get; set; }
    public CartItem CartItem { get; set; }
    public int Stock { get; set; }
    public ICollection<Review> Reviews { get; set; }

}
