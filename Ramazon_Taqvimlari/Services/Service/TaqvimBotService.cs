using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Services.Service;

public class TaqvimBotService : ITaqvimBotService
{

    private readonly MainContext mainContext;

    public TaqvimBotService(MainContext mainContext)
    {
        this.mainContext = mainContext;
    }

    public async Task AddUserAsync(BotUser user)
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

    public Task<List<BotUser>> GetAllUsersAsync()
    {
        var users = mainContext.Users.ToListAsync();
        return users;
    }

    public async Task UpdateUserAsync(BotUser user)
    {
        var dbUser = await mainContext.Users.FirstOrDefaultAsync(x => x.TelegramUserId == user.TelegramUserId);
        dbUser = user;
        mainContext.Users.Update(dbUser);
        await mainContext.SaveChangesAsync();
    }

}
