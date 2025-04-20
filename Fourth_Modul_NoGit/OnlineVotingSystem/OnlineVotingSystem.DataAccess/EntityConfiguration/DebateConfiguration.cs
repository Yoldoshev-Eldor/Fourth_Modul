using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineVotingSystem.DataAccess.Entities;

namespace OnlineVotingSystem.DataAccess.EntityConfiguration;

public class DebateConfiguration : IEntityTypeConfiguration<Debate>
{
    public void Configure(EntityTypeBuilder<Debate> builder)
    {
        throw new NotImplementedException();
    }
}
