using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineVotingSystem.DataAccess.Entities;

namespace OnlineVotingSystem.DataAccess.EntityConfiguration
{
    public class CampaignConfiguration : IEntityTypeConfiguration<Campaign>
    {
        public void Configure(EntityTypeBuilder<Campaign> builder)
        {
            throw new NotImplementedException();
        }
    }
}
