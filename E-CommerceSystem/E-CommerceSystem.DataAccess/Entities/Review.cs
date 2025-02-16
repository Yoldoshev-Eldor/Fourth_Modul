namespace E_CommerceSystem.DataAccess.Entities;

public class Review
{
    public long ReviewId { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
    public long ProductId { get; set; }
    public Product Product { get; set; }
    public double Rating { get; set; }
    public string Comment { get; set; }


}
