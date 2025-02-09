using Instagram.Bll.Dtos;
using Instagram.Dal.Entities;
using Instagram.Repository.Services;

namespace Instagram.Bll.Services;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;

    public PostService(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<long> AddPostAsync(PostCreateDto postDto)
    {
        var post = new Post()
        {

            PostType = postDto.PostType,
            CreatedTime = postDto.CreatedTime,
            AccountId = postDto.AccountId,


        };
        var res = await _postRepository.AddPostAsync(post);
        return res;
    }

    public async Task<List<PostGetDto>> GetAllPostAsync()
    {
        var postEntiti = await _postRepository.GetAllPostAsync();

        var post = new List<PostGetDto>();
        foreach (var pos in postEntiti)
        {
            var dto = new PostGetDto()
            {
                PostId = pos.PostId,
                CreatedTime = pos.CreatedTime,
                PostType = pos.PostType,
                AccountId = pos.AccountId,
            };
            post.Add(dto);
        }
        return post;
    }

    public async Task<PostGetDto> GetPostByIdAsync(long id)
    {
        var posts =await GetAllPostAsync();
        var res =  posts.FirstOrDefault(x => x.PostId == id);
        if(res == null)
        {
            throw new Exception("null");
        }
        return res;
    }
}
