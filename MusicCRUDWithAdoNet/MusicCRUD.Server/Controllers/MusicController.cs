using Microsoft.AspNetCore.Mvc;
using MusicCRUD.Service;
using MusicCRUD.Service.DTOs;

namespace MusicCRUD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMusicService _musicService;

        public MusicController(IMusicService musicService)
        {
            _musicService = musicService;
        }

        [HttpPost("Add Music")]
        public async Task<Guid> AddMusic(MusicDto music)
        {
            return await _musicService.AddMusicAsync(music);
        }
        [HttpGet("getMusics")]
        public async Task<List<MusicDto>> GetMusics()
        {
            return await _musicService.GetAllMusicAsync();
        }
        [HttpPut("updateMusic")]
        public async Task UpdateMusic(MusicDto music)
        {
           await _musicService.UpdateMusicAsync(music);
        }
        [HttpDelete("deleteMusic")]
        public async Task DeleteMusic(Guid id)
        {
           await _musicService.DeleteMusicAsync(id);
        }
        [HttpGet("GetTotalMusicSizeByAuthor")]
        public async Task<double> GetTotalMusicSizeByAuthorAsync(string authorName)
        {
            return await _musicService.GetTotalMusicSizeByAuthorAsync(authorName);            
        }
        [HttpGet("GetMusicWithLikesInRange")]
        public async Task<List<MusicDto>> GetMusicWithLikesInRange(int minLikes, int maxLikes)
        {
            return await _musicService.GetMusicWithLikesInRangeAsync(minLikes, maxLikes);
        }
        [HttpGet("GetMusicByDescriptionKeyword")]
        public async Task<List<MusicDto>> GetMusicByDescriptionKeyword(string keyword)
        {
            return await _musicService.GetMusicByDescriptionKeywordAsync(keyword);
        }
        [HttpGet("GetTopMostLikedMusic")]
        public async Task<List<MusicDto>> GetTopMostLikedMusic(int count)
        {
            return await _musicService.GetTopMostLikedMusicAsync(count);
        }
        [HttpGet("GetAllMusicAboveSize")]
        public async Task<List<MusicDto>> GetAllMusicAboveSize(double minSize)
        {
            return await _musicService.GetAllMusicAboveSizeAsync(minSize);
        }
        [HttpGet("GetMusicByName")]
        public async Task<MusicDto> GetMusicByName(string name)
        {
            return await _musicService.GetMusicByNameAsync(name);
        }
        [HttpGet("GetMostLikedMusic")]
        public async Task<MusicDto> GetMostLikedMusic()
        {
            return await _musicService.GetMostLikedMusicAsync();
        }
        [HttpGet("GetAllMusicByAuthorName")]
        public async Task<List<MusicDto>> GetAllMusicByAuthorName(string name)
        {
            return await _musicService.GetAllMusicByAuthorNameAsync(name);
        }
    }
}
