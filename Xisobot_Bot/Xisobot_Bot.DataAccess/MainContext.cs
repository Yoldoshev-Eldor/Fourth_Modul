using DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;
using Xisobot_Bot.DataAccess.Entities;

namespace Xisobot_Bot.DataAccess;

public class MainContext : DbContext
{
    public DbSet<BotUser> Users { get; set; }
    public DbSet<Transaction> Transactions { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = "Data Source=DESKTOP-40PGLKA;User ID=sa;Password=1;Initial Catalog=XisobotBot;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new TransactionConfiguration());
       
    }


}
