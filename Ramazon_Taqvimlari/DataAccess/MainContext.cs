using DataAccess.Entities;
using DataAccess.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class MainContext : DbContext
{
    public DbSet<BotUser> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = "Data Source=DESKTOP-40PGLKA;User ID=sa;Password=1;Initial Catalog=RamazonTaqvimi_Users;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BotUserConfiguration());
    }

}
