using Microsoft.Data.SqlClient;
using MsicCRUD.DataAccess.Entity;
using MusicCRUD.Repostory.Settings;

namespace MusicCRUD.Repostory.Services;

public class MusicRepostoryAdoNet : IMusicRepostory
{
    private readonly string _connectionString;
    public MusicRepostoryAdoNet(SqlConectionString sqlConnectionString)
    {
        _connectionString = sqlConnectionString.ConnectionString;
    }
    public async Task<long> AddMusicAsync(Music music)
    {
        string sql = @"
                 Insert into Music (Name, Mb, AuthorName, Description, QuentityLikes)
                 OutPut Inserted.MusicId
                 Values (@Name, @Mb, @AuthorName, @Description, @QuentityLikes);";
        using (var conn = new SqlConnection(_connectionString) )
        {
            await conn.OpenAsync();

            using(var cmd = new SqlCommand(sql,conn))
            {

                cmd.Parameters.AddWithValue("@Name", music.Name);
                cmd.Parameters.AddWithValue("@MB", music.MB);
                cmd.Parameters.AddWithValue("@AuthorName", music.AuthorName);
                cmd.Parameters.AddWithValue("@Description", music.Description);
                cmd.Parameters.AddWithValue("@QuentityLikes", music.QuentityLikes);


                var result = (long)await cmd.ExecuteScalarAsync();

                await conn.CloseAsync();
                return result;
            }


        }
    }


    public Task DeleteMusicAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Music>> GetAllMusicAsync()
    {
        throw new NotImplementedException();
    }

  

    public Task<Music> GetMusicByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateMusicAsync(Music music)
    {
        throw new NotImplementedException();
    }
}
