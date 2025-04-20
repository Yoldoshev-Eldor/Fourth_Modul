using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineVotingSystem.DataAccess.Entities;

namespace OnlineVotingSystem.DataAccess.EntityConfiguration;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        throw new NotImplementedException();
    }
}
