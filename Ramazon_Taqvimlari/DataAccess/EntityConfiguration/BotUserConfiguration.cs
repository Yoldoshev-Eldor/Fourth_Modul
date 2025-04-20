using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfiguration;

public class BotUserConfiguration : IEntityTypeConfiguration<BotUser>

{
    public void Configure(EntityTypeBuilder<BotUser> builder)
    {
        builder.ToTable("User");
        builder.HasKey(u => u.BotUserId);

        builder.HasIndex(u => u.TelegramUserId).IsUnique(true);
    }
}
