using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valyuta_bot.DataAccess.Entities;

namespace Valyuta_bot.DataAccess.EntityConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<TelegramUser>
{
    public void Configure(EntityTypeBuilder<TelegramUser> builder)
    {
        builder.ToTable("User");
        builder.HasKey(u => u.BotUserId);

        builder.HasIndex(u => u.TelegramUserId).IsUnique(true);
    }
}