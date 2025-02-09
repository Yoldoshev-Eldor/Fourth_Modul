using Instagram.Bll.Dtos;
using Instagram.Bll.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Server.Controllers
{
    [Route("api/Post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _service;

        public PostController(IPostService service)
        {
            _service = service;
        }
        [HttpGet("GetAll")]
        public async Task<List<PostGetDto>>GetAll()
        {
            return await _service.GetAllPostAsync();
        }
        [HttpGet("addpost")]
        public async Task<long>AddPost(PostGetDto post)
        {
            return await _service.AddPostAsync(post);
        }
        [HttpGet("getById")]
        public async Task<PostGetDto>PostById(long id)
        {
            return await _service.GetPostByIdAsync(id);
        }

    }
}
