using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineVotingSystem.DataAccess.Entities;

namespace OnlineVotingSystem.DataAccess.EntityConfiguration;

public class ElectionConfiguration : IEntityTypeConfiguration<Election>
{
    public void Configure(EntityTypeBuilder<Election> builder)
    {
        throw new NotImplementedException();
    }
}
