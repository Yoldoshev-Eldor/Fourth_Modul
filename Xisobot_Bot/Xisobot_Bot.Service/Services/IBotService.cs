using Xisobot_Bot.DataAccess.Entities;

namespace Xisobot_Bot.Service.Services;

public interface IBotService
{
    Task AddUserAsync(BotUser user);
    Task UpdateUserAsync(BotUser user);
    Task<List<BotUser>> GetAllUsersAsync();
    Task<BotUser> GetBotUserByTelegramUserIdAsync(long telegramUserId);


}