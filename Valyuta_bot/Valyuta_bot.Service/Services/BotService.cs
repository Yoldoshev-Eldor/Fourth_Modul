using Valyuta_bot.DataAccess.Entities;
using Valyuta_bot.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Valyuta_bot.Service.Services;

public class BotService : IBotService
{
    private readonly MainContext mainContext;

    public BotService(MainContext mainContext)
    {
        this.mainContext = mainContext;
    }

    public async Task AddUserAsync(TelegramUser user)
    {
        var dbUser = await mainContext.Users.FirstOrDefaultAsync(x => x.TelegramUserId == user.TelegramUserId);

        if (dbUser != null)
        {
            Console.WriteLine($"User with id : {user.TelegramUserId} already exists");
            return;
        }

        try
        {
            await mainContext.Users.AddAsync(user);
            await mainContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public Task<List<TelegramUser>> GetAllUsersAsync()
    {
        var users = mainContext.Users.ToListAsync();
        return users;
    }

    public async Task UpdateUserAsync(TelegramUser user)
    {
        var dbUser = await mainContext.Users.FirstOrDefaultAsync(x => x.TelegramUserId == user.TelegramUserId);
        dbUser = user;
        mainContext.Users.Update(dbUser);
        await mainContext.SaveChangesAsync();
    }
}
