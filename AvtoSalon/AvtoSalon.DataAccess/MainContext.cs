using AvtoSalon.DataAccess.EntitieConfiguration;
using AvtoSalon.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvtoSalon.DataAccess;

public class MainContext : DbContext
{
    public DbSet<AvtoSalonn> AvtoSalons { get; set; }
    public DbSet<Car> Cars { get; set; }



    public MainContext(DbContextOptions<MainContext> options)
        : base(options)
    {
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    if (!optionsBuilder.IsConfigured)
    //    {
    //        optionsBuilder.UseSqlServer("Data Source=localhost\\SQLDEV;User ID=sa;Password=akobirakoone;Initial Catalog=IdentityHub;TrustServerCertificate=True;");
    //    }
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AvtoSalonConfiguration());
        modelBuilder.ApplyConfiguration(new CarConfiguration());

    }
}

