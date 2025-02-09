using Instagram.Bll.Dtos;
using Instagram.Dal.Entities;

namespace Instagram.Bll.Services;

public interface IPostService
{
    Task<long> AddPostAsync(PostCreateDto post);

    Task<PostGetDto> GetPostByIdAsync(long id);

    Task<List<PostGetDto>> GetAllPostAsync();
    Task<long> AddPostAsync(PostGetDto post);
}