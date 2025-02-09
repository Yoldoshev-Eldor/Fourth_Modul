using AvtoSalon.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvtoSalon.DataAccess.EntitieConfiguration;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable("Car");

        builder.HasKey(c => c.CarId);

        builder.HasIndex(c => c.CarName)
            .IsUnique();


        builder.Property(c => c.CarName)
            .IsRequired(true)
            .HasMaxLength(50);


  


    }
}
