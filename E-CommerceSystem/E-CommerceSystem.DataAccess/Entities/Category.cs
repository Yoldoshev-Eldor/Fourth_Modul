namespace E_CommerceSystem.DataAccess.Entities;

public class Category
{
    public long CategoryId { get; set; }
    public string Name { get; set; }
    public ICollection<Product> Products { get; set; }
    public Category? ParentCategoryId { get; set; }


}
