using Instagram.Dal.Entities;

namespace Instagram.Repository.Services;

public interface IPostRepository
{
    Task<long> AddPostAsync(Post post);

    Task<Post> GetPostByIdAsync(long id);

    Task<List<Post>> GetAllPostAsync();

}