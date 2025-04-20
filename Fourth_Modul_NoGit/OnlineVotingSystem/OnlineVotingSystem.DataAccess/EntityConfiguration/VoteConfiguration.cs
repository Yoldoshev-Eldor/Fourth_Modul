using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineVotingSystem.DataAccess.Entities;

namespace OnlineVotingSystem.DataAccess.EntityConfiguration
{
    public class VoteConfiguration : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            throw new NotImplementedException();
        }
    }
}
