using Microsoft.EntityFrameworkCore;
using OnlineLearningPlatform.DataAccess;

namespace OnlineLearningPlatform.Server.Configuration;

public static class DataBaseConfiguration
{

    public static void ConfigureDatabase(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
        builder.Services.AddDbContext<MainContext>(options =>
          options.UseSqlServer(connectionString));
    }

}
