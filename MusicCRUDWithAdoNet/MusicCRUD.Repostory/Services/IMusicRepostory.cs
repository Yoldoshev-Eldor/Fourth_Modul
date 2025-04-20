using MsicCRUD.DataAccess.Entity;

namespace MusicCRUD.Repostory.Services;

public interface IMusicRepostory
{
    /// <summary>
    /// This method add new music to our storage.
    /// It gets as argument Music music and returns id.
    /// </summary>
    /// <param name="music"></param>
    /// <returns></returns>
    Task<long> AddMusicAsync(Music music);

    /// <summary>
    /// This method removes music from storage.
    /// </summary>
    /// <param name="id"></param>
    Task DeleteMusicAsync(long id);

    Task UpdateMusicAsync(Music music);
    Task<Music> GetMusicByIdAsync(long id);
    Task<List<Music>> GetAllMusicAsync();
}