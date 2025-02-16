using E_CommerceSystem.DataAccess.Enums;

namespace E_CommerceSystem.DataAccess.Entities;

public class User
{
    public long UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public UserRole Role { get; set; }
    public ICollection<Order> Orders { get; set; }
    public Cart Cart { get; set; }
    public ICollection<Review> Reviews { get; set; }
}
