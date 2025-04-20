using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xisobot_Bot.DataAccess;
using Xisobot_Bot.DataAccess.Entities;

namespace Xisobot_Bot.Service.Services;

public class BotService : IBotService
{

    private readonly MainContext mainContext;

    public BotService(MainContext mainContext)
    {
        this.mainContext = mainContext;
    }

    public async Task AddUserAsync(BotUser user)
    {
        // Foydalanuvchi allaqachon mavjudligini tekshirish
        var existingUser = await mainContext.Users
            .FirstOrDefaultAsync(u => u.TelegramUserId == user.TelegramUserId);

        if (existingUser != null)
        {
            Console.WriteLine($"User with telegram id {user.TelegramUserId} already exists.");
            return; // Agar user mavjud bo‘lsa, xatolik qaytarmasdan qaytish
        }

        try
        {
            await mainContext.Users.AddAsync(user);
            await mainContext.SaveChangesAsync();
            Console.WriteLine($"User with telegram id {user.TelegramUserId} added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR] {ex.Message}");
        }
    }



    public Task<List<BotUser>> GetAllUsersAsync()
    {
        var users = mainContext.Users.ToListAsync();
        return users;
    }

    public async Task<BotUser> GetBotUserByTelegramUserIdAsync(long telegramUserId)
    {
        var botUser = await mainContext.Users.FirstOrDefaultAsync(u => u.TelegramUserId == telegramUserId);

        if (botUser == null)
        {
            Console.WriteLine($"User with telegram id is not fount : {telegramUserId}");
        }

        return botUser;
    }

   

    public async Task UpdateUserAsync(BotUser user)
    {
        var dbUser = await mainContext.Users.FirstOrDefaultAsync(x => x.TelegramUserId == user.TelegramUserId);
        dbUser = user;
        mainContext.Users.Update(dbUser);
        await mainContext.SaveChangesAsync();
    }






}
