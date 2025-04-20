using DataAccess.Entities;

namespace Services.Service;

public interface ITaqvimBotService
{
    Task AddUserAsync(BotUser user);
    Task UpdateUserAsync(BotUser user);
    Task<List<BotUser>> GetAllUsersAsync();


}