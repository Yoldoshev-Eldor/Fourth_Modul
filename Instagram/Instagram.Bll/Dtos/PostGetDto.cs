using Instagram.Dal.Entities;

namespace Instagram.Bll.Dtos;

public class PostGetDto
{
    public long PostId { get; set; }
    public DateTime CreatedTime { get; set; }
    public string PostType { get; set; }

    public long AccountId { get; set; }
    public Account Account { get; set; }

    public List<Comment> Comments { get; set; }

}
