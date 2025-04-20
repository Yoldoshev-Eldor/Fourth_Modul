using Microsoft.EntityFrameworkCore;
using MsicCRUD.DataAccess.Entity;
using MusicCRUD.Repostory.Settings;
using Microsoft.Data.SqlClient;

namespace MusicCRUD.Api.Configuration
{
    public static class DataBaseConfiguration
    {

        public static void ConfigureDatabase(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
            var sqlConectionString = new SqlConectionString(connectionString);


            builder.Services.AddSingleton<SqlConectionString>(sqlConectionString);

            builder.Services.AddDbContext<MainContext>(options =>
              options.UseSqlServer(connectionString));
        }

    
    }
}
