using Instagram.Dal;
using Instagram.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace Instagram.Repository.Services;

public class PostRepository : IPostRepository
{
    private readonly MainContext _mainContext;

    public PostRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }

    public async Task<long> AddPostAsync(Post post)
    {
      await  _mainContext.Posts.AddAsync(post);
      await  _mainContext.SaveChangesAsync();
        return post.PostId;
    }

    public async Task<List<Post>> GetAllPostAsync()
    {
        return await _mainContext.Posts.Include(p => p.Comments).ToListAsync();
    }

    public async Task<Post> GetPostByIdAsync(long id)
    {
        var post =await _mainContext.Posts.FirstOrDefaultAsync(p => p.PostId == id);
        if (post == null)
        {
            throw new Exception("null");
        }
        return post;
    }
}
