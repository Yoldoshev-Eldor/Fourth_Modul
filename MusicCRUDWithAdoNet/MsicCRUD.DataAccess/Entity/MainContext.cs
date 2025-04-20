using Microsoft.EntityFrameworkCore;

namespace MsicCRUD.DataAccess.Entity;

public class MainContext : DbContext
{
    public DbSet<Music> Music { get; set; }

  

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-40PGLKA;Database=YourDatabaseName;User Id=sa;Password=1;TrustServerCertificate=True;");
        }

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

}
