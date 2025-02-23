using Microsoft.EntityFrameworkCore;
using Valyuta_bot.DataAccess.Entities;
using Valyuta_bot.DataAccess.EntityConfiguration;

namespace Valyuta_bot.DataAccess;

public class MainContext : DbContext
{
    public DbSet<TelegramUser> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = "Data Source=DESKTOP-40PGLKA;User ID=sa;Password=1;Initial Catalog=ValyutaBot;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}