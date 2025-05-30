﻿using AvtoSalon.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AvtoSalon.Server.Configuration;

public static class DataBaseConfiguration
{
    public static void ConfigureDatabase(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
        builder.Services.AddDbContext<MainContext>(options =>
          options.UseSqlServer(connectionString));
    }
}