using Valyuta_bot.DataAccess.Entities;

namespace Valyuta_bot.Service.Services;

public interface IBotService
{
    Task AddUserAsync(TelegramUser user);
    Task UpdateUserAsync(TelegramUser user);
    Task<List<TelegramUser>> GetAllUsersAsync();
}