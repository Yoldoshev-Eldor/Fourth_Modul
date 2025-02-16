using E_CommerceSystem.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceSystem.Server.Configuration;

public static class DatabaseConfiguration
{
    public static void ConfigureDatabase(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
        builder.Services.AddDbContext<MainContext>(o =>
          o.UseSqlServer(connectionString));
    }

}
